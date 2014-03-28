using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team537.Scouting.Model
{
    using Newtonsoft.Json;

    public class Match : NotifyObject
    {
        [JsonIgnore]
        public Competition Competition { get; set; }
        public MatchType MatchType { get; set; }
        public int MatchNumber { get; set; }
        public Team Red1 { get; set; }
        public Team Red2 { get; set; }
        public Team Red3 { get; set; }
        public Team Blue1 { get; set; }
        public Team Blue2 { get; set; }
        public Team Blue3 { get; set; }
    }
}
