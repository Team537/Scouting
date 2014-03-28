using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    public class MatchSummaryData2014
    {
        public static MatchSummaryData2014 Calculate(Team team, int matchesToInclude)
        {
            var summaryData = new MatchSummaryData2014();
            var matchData = matchesToInclude > 0 ? team.MatchData2014.OrderByDescending(t => t.MatchNumber).Take(matchesToInclude).ToArray() : team.MatchData2014.ToArray();
            var matchCount = matchData.Length;

            if (matchCount == 0)
            {
                return summaryData;
            }

            summaryData.MatchCount = matchCount;
            
            // set up
            summaryData.StartingPositionSidePct = matchData.Count(m => m.StartingPosition == StartingPosition.Side) / (double)matchCount;
            summaryData.StartingPositionMiddlePct = matchData.Count(m => m.StartingPosition == StartingPosition.Middle) / (double)matchCount;
            summaryData.StartingPositionGoaliePct = matchData.Count(m => m.StartingPosition == StartingPosition.Goalie) / (double)matchCount;

            // autonomous
            summaryData.MobilityPct = matchData.Count(m => m.Mobility) / (double)matchCount;
            summaryData.AutonomousHighPct = matchData.Sum(m => m.AutonomousHigh + m.AutonomousHighHot) / (double)matchCount;
            summaryData.AutonomousHighHotPct = summaryData.AutonomousHigh > 0 ? matchData.Sum(m => m.AutonomousHighHot) / (double)summaryData.AutonomousHigh : 0;

            summaryData.AutonomousLowPct = matchData.Sum(m => m.AutonomousLow + m.AutonomousLowHot) / (double)matchCount;
            summaryData.AutonomousLowHotPct = summaryData.AutonomousLow > 0 ? matchData.Sum(m => m.AutonomousLowHot) / (double)summaryData.AutonomousLow : 0;

            // offensive
            summaryData.TeleOperatedHighPerMatch = matchData.Sum(m => m.TeleOperatedHighGoal) / (double)matchCount;
            var highGoalAttempts = matchData.Sum(m => m.TeleOperatedHighGoalMiss + m.TeleOperatedHighGoal);
            if (highGoalAttempts > 0)
            {
                summaryData.TeleOperatedHighPercent = matchData.Sum(m => m.TeleOperatedHighGoal) / (double)highGoalAttempts;
            }

            summaryData.TeleOperatedLowPerMatch = matchData.Sum(m => m.TeleOperatedLowGoal) / (double)matchCount;

            summaryData.TeleOperatedTrussPerMatch = matchData.Sum(m => m.TeleOperatedTruss) / (double)matchCount;
            summaryData.TeleOperatedCatchPerMatch = matchData.Sum(m => m.TeleOperatedCatch) / (double)matchCount;
            
            // posessions
            summaryData.PossessionCount = matchData.Sum(m => m.TeleOperatedPossessionFront + m.TeleOperatedPossessionMiddle + m.TeleOperatedPossessionBack);
            if (summaryData.PossessionCount > 0)
            {
                summaryData.PosessionFrontPct = matchData.Sum(m => m.TeleOperatedPossessionFront) / (double)summaryData.PossessionCount;
                summaryData.PosessionMiddlePct = matchData.Sum(m => m.TeleOperatedPossessionMiddle) / (double)summaryData.PossessionCount;
                summaryData.PosessionBackPct = matchData.Sum(m => m.TeleOperatedPossessionBack) / (double)summaryData.PossessionCount;
            }

            summaryData.TeleOperatedBallsLost = matchData.Sum(m => m.TeleOperatedBallsLost.GetValueOrDefault()) / (double)matchCount;

            // defense
            summaryData.ShotsDefendedPerMatch = matchData.Sum(m => m.ShotsDefended) / (double)matchCount;
            summaryData.RobotContactsPerMatch = matchData.Sum(m => m.RobotContact) / (double)matchCount;
            summaryData.PinnedOpponentsPerMatch = matchData.Sum(m => m.PinnedOpponents) / (double)matchCount;

            // other
            summaryData.FoulsPerMatch = matchData.Sum(m => m.Fouls) / (double)matchCount;

            // comments
            summaryData.OverallComments = string.Join(Environment.NewLine + "-------" + Environment.NewLine, matchData.OrderByDescending(m => m.MatchNumber).Take(matchesToInclude).Select(m => m.OverallComments));
            summaryData.ManuverabilityComments = string.Join(Environment.NewLine + "-------" + Environment.NewLine, matchData.OrderByDescending(m => m.MatchNumber).Take(matchesToInclude).Select(m => m.ManuverabilityComments));
            summaryData.ShooterComments = string.Join(Environment.NewLine + "-------" + Environment.NewLine, matchData.OrderByDescending(m => m.MatchNumber).Take(matchesToInclude).Select(m => m.ShooterComments));
            summaryData.CollectorComments = string.Join(Environment.NewLine + "-------" + Environment.NewLine, matchData.OrderByDescending(m => m.MatchNumber).Take(matchesToInclude).Select(m => m.CollectorComments));

            return summaryData;
        }

        public double AutonomousLowPct { get; set; }

        public double AutonomousHighPct { get; set; }

        public string CollectorComments { get; set; }

        public string ShooterComments { get; set; }

        public string ManuverabilityComments { get; set; }

        public string OverallComments { get; set; }

        public double TeleOperatedBallsLost { get; set; }

        public double TeleOperatedHighPercent { get; set; }

        public int PossessionCount { get; set; }

        public double PinnedOpponentsPerMatch { get; set; }

        public double RobotContactsPerMatch { get; set; }

        public double PosessionBackPct { get; set; }

        public double PosessionMiddlePct { get; set; }

        public double PosessionFrontPct { get; set; }

        public double ShotsDefendedPerMatch { get; set; }

        public double FoulsPerMatch { get; set; }

        public int MatchCount { get; set; }

        public double TeleOperatedCatchPerMatch { get; set; }

        public double TeleOperatedTrussPerMatch { get; set; }

        public double TeleOperatedLowPerMatch { get; set; }

        public double TeleOperatedHighPerMatch { get; set; }

        public double StartingPositionSidePct { get; set; }

        public double StartingPositionGoaliePct { get; set; }

        public double StartingPositionMiddlePct { get; set; }

        public double MobilityPct { get; set; }

        public double AutonomousLowHotPct { get; set; }

        public int AutonomousLow { get; set; }

        public int AutonomousHigh { get; set; }

        public double AutonomousHighHotPct { get; set; }
    }
}
