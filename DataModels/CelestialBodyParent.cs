using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModels
{
    public class CelestialBodyParent : DictionaryModelBase<string, int>
    {
        [Required]
        public virtual CelestialBody Body { get; set; }
        public long BodyId { get; set; }
    }
}
