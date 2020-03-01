﻿using Ionic.Zlib;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EddnSubscriber
{
    public class EddnSubscriberService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ILogger<EddnSubscriberService> _logger;
        private readonly EddnSettings _options;
        private readonly SubscriberSocket _subscriberSocket;
        private readonly UTF8Encoding _encoding;

        public EddnSubscriberService(
            IHostApplicationLifetime appLifetime, 
            ILogger<EddnSubscriberService> logger,
            IOptionsSnapshot<EddnSettings> options)
        {
            _appLifetime = appLifetime;
            _logger = logger;
            _options = options.Value;
            _subscriberSocket = new SubscriberSocket();
            _subscriberSocket.Options.ReceiveHighWatermark = _options.ReceiveHighWatermark;
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _encoding = new UTF8Encoding();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriberSocket.Connect(_options.Address);
            _subscriberSocket.SubscribeToAnyTopic();
            while (true)
            {
                var bytesReceived = _subscriberSocket.ReceiveFrameBytes();
                var uncompressed = ZlibStream.UncompressBuffer(bytesReceived);
                var entity = _encoding.GetString(uncompressed);
                _logger.LogInformation(entity);
            }
        }

        private void OnStopping()
        {
            _subscriberSocket.Dispose();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
