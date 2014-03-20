using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model.Import
{
    using Newtonsoft.Json;

    public class TeamMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("match-data")]
        public Dictionary<int, MatchImportScoutingData2014> Matches { get; set; }
    }
}
