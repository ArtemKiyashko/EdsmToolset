using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace EdsmDbImporter
{
    public interface IImportActionFactory
    {
        Task ImportAsync<T>(DbContext context, IEnumerable<T> entities, Action<BulkOperation<T>> options) where T : class;
    }
}
