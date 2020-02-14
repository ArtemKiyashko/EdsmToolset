using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    public interface IDbImporter
    {
        Task ImportSystemsAsync();
        Task ImportBodiesAsync();
    }
}
