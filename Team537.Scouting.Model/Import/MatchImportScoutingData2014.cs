using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    using Newtonsoft.Json;

    public class MatchImportScoutingData2014
    {
        public int MatchNumber { get; set; }

        [JsonProperty("autonomous-scoring-3-high-hot")]
        public int AutonomousHighHot { get; set; }

        [JsonProperty("autonomous-scoring-3-high")]
        public int AutonomousHigh { get; set; }

        [JsonProperty("autonomous-scoring-3-low-hot")]
        public int AutonomousLowHot { get; set; }

        [JsonProperty("autonomous-scoring-3-low")]
        public int AutonomousLow { get; set; }

        [JsonProperty("autonomous-scoring-3-none")]
        public int AutonomousNone { get; set; }

        [JsonProperty("autonomous-mobility")]
        public string Mobility { get; set; }

        [JsonProperty("autonomous-starting-position")]
        public string StartingPosition { get; set; }

        [JsonProperty("teleoperated-cycle-front-count")]
        public int TeleOperatedPossessionFront { get; set; }

        [JsonProperty("teleoperated-cycle-middle-count")]
        public int TeleOperatedPossessionMiddle { get; set; }

        [JsonProperty("teleoperated-cycle-back-count")]
        public int TeleOperatedPossessionBack { get; set; }

        [JsonProperty("teleoperated-truss-truss")]
        public int TeleOperatedTruss { get; set; }

        [JsonProperty("teleoperated-truss-truss-fail")]
        public int TeleOperatedTrussFail { get; set; }

        [JsonProperty("teleoperated-catch-catch")]
        public int TeleOperatedCatch { get; set; }

        [JsonProperty("teleoperated-catch-fail")]
        public int TeleOperatedCatchFail { get; set; }

        [JsonProperty("teleoperated-scoring-2-high-goal")]
        public int TeleOperatedHighGoal { get; set; }

        [JsonProperty("teleoperated-scoring-2-high-miss")]
        public int TeleOperatedHighGoalMiss { get; set; }

        [JsonProperty("teleoperated-scoring-2-low")]
        public int TeleOperatedLowGoal { get; set; }

        [JsonProperty("teleoperated-balls-lost")]
        public int? TeleOperatedBallsLost { get; set; }

        [JsonProperty("teleoperated-fouls-2")]
        public int? Technicals { get; set; }

        [JsonProperty("teleoperated-fouls")]
        public int? Fouls { get; set; }

        [JsonProperty("teleoperated-defensive-shots-blocked")]
        public int ShotsDefended { get; set; }

        [JsonProperty("teleoperated-defensive-defensive-contact")]
        public int DefensiveContacts { get; set; }

        [JsonProperty("teleoperated-defensive-pinnings")]
        public int PinnedOpponents { get; set; }

        [JsonProperty("comments-maneuverability-3")]
        public string ManuverabilityComments { get; set; }

        [JsonProperty("comments-collector")]
        public string CollectorComments { get; set; }

        [JsonProperty("comments-shooter")]
        public string ShooterComments { get; set; }

        [JsonProperty("comments-general")]
        public string OverallComments { get; set; }
    }
}
