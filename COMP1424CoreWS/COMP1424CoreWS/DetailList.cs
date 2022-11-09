using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace COMP1424CoreWS
{
    public class DetailList
    {
        public string name { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> otherDetails { get; set; }
    }
}
