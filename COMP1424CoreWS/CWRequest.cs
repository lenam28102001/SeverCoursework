using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace COMP1424CoreWS
{
    public class CWRequest
    {
        public string userId { get; set; }

        public List<DetailList> detailList { get; set; }
    }
}
