using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawDataImporter
{
    using System.ComponentModel.DataAnnotations;

    public class ImportantMatchData
    {
        [Key]
        public int MatchId { get; set; }
        public int MatchNumber { get; set; }
        public int TeamNumber { get; set; }
        public int AutonomousHighMade { get; set; }
        public int TrussesMade { get; set; }
        public int TrussesAttempted { get; set; }
        public int Catches { get; set; }
        public int Possessions { get; set; }
        public int HighGoals { get; set; }
        public int HighGoalsAttempted { get; set; }
        public int BallsDropped { get; set; }
    }
}
