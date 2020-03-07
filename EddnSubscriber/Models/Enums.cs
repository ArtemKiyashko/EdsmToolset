using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public enum EddnEvent
    {
        Unknown,
        FSDJump,
        Scan,
        Location
    }
}
