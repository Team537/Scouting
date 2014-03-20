using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model.Import
{
    using Newtonsoft.Json;

    public class MatchImportModel
    {
        [JsonProperty("blue1")]
        public int Blue1 { get; set; }

        [JsonProperty("blue2")]
        public int Blue2 { get; set; }

        [JsonProperty("blue3")]
        public int Blue3 { get; set; }

        [JsonProperty("red1")]
        public int Red1 { get; set; }

        [JsonProperty("red2")]
        public int Red2 { get; set; }

        [JsonProperty("red3")]
        public int Red3 { get; set; }
    }
}
