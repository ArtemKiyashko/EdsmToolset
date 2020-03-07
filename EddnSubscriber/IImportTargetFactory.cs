using EddnSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EddnSubscriber
{
    public interface IImportTargetFactory
    {
        Task ImportAsync(string entity);
    }
}
