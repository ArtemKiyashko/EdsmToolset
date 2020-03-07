using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter
{
    public interface IDbImporter
    {
        Task ImportSystemsAsync();
        Task ImportBodiesAsync();
        Task ImportBodyAsync(CelestialBody celestialBody);
        Task ImportSystemAsync(EdSystem edSystem);
    }
}
