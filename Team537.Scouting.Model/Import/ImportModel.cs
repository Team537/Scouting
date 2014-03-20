using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model.Import
{
    using Newtonsoft.Json;

    public class ImportModel
    {
        [JsonProperty("matches")]
        public Dictionary<int, MatchImportModel> Matches { get; set; }

        [JsonProperty("teams")]
        public Dictionary<int, TeamMetadata> Teams { get; set; }
    }
}
