using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public static class Conststants
    {
        public static readonly List<Uri> ValidRefs = new List<Uri> { 
            new Uri("https://eddn.edcd.io/schemas/journal/1")
        };
    }
}
