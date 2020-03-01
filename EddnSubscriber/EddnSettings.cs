using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber
{
    public class EddnSettings
    {
        public string Address { get; set; }
        public int ReceiveHighWatermark { get; set; }
    }
}
