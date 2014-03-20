using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model.Import
{
    public class AutonomousData
    {
        public Dictionary<string, AutonomousGoalData> Goals { get; set; }
        public Dictionary<string, AutonmousMobilityData> Mobility { get; set; }
        public Dictionary<string, string> StartingPosition { get; set; } 
    }

    public class AutonmousMobilityData
    {
        public int Yes { get; set; }
        public int No { get; set; }
    }

    public class AutonomousGoalData
    {
        public int HighHot { get; set; }
        public int High { get; set; }
        public int LowHot { get; set; }
        public int Low { get; set; }
    }
}
