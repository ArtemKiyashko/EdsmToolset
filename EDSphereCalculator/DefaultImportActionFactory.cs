using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace EdsmDbImporter
{
    public class DefaultImportActionFactory : IImportActionFactory
    {
        private readonly CmdOptions _cmdOptions;

        public DefaultImportActionFactory(CmdOptions cmdOptions)
        {
            _cmdOptions = cmdOptions;
        }

        public Task ImportAsync<T>(DbContext context, IEnumerable<T> entities, Action<BulkOperation<T>> options) where T : class
        {
            return _cmdOptions.Action switch
            {
                ActionTypes.Insert => context.BulkInsertAsync(entities, options),
                ActionTypes.Merge => context.BulkMergeAsync(entities, options),
                _ => throw new ArgumentException("Wrong action specified", nameof(_cmdOptions.Action)),
            };
        }
    }
}
