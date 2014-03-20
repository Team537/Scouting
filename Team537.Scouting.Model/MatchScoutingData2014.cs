using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    public class MatchScoutingData2014 : NotifyObject
    {
        public int MatchNumber { get; set; }

        public int AutonomousHighHot { get; set; }

        public int AutonomousHigh { get; set; }

        public int AutonomousLowHot { get; set; }

        public int AutonomousLow { get; set; }

        public bool Mobility { get; set; }

        public StartingPosition StartingPosition { get; set; }

        public int TeleOperatedPossessionFront { get; set; }

        public int TeleOperatedPossessionMiddle { get; set; }
        
        public int TeleOperatedPossessionBack { get; set; }

        public int TeleOperatedTruss { get; set; }

        public int TeleOperatedCatch { get; set; }

        public int TeleOperatedHighGoal { get; set; }

        public int TeleOperatedLowGoal { get; set; }

        public int Fouls { get; set; }

        public HumanPlayerPosition HumanPlayerPosition { get; set; }

        public int Manuverability { get; set; }

        public int RobotContact { get; set; }

        public int ShotsDefended { get; set; }

        public int DefensiveContacts { get; set; }

        public int PinnedOpponents { get; set; }
        
        public string CollectorComments { get; set; }

        public string ShooterComments { get; set; }

        public string OverallComments { get; set; }

        public int TeleOperatedCatchFail { get; set; }
        public int TeleOperatedHighGoalMiss { get; set; }
        public int? TeleOperatedBallsLost { get; set; }
        public string ManuverabilityComments { get; set; }
    }
}
