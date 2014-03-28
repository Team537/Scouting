using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.Data
{
    using System.IO;
    using System.Net.Http;

    using Windows.Storage;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Team537.Scouting.Model;
    using Team537.Scouting.Model.Import;

    public class MatchDataImporter
    {
        public static async Task<ImportModel> ImportRemoteData(Competition competition, string serverAddress)
        {
            var importModel = new ImportModel();

            //var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            //var file = await folder.GetFileAsync("matches.json");

            var client = new HttpClient();
            var uri = new Uri(serverAddress, UriKind.Absolute);
            using (var downloadStream = await client.GetStreamAsync(uri))
            //using (var fileData = await file.OpenReadAsync())
            {
                using (var stringreader = new StreamReader(downloadStream))
                {
                    using (var jsonReader = new JsonTextReader(stringreader))
                    {
                        var jsonSerializer = new JsonSerializer();
                        importModel = jsonSerializer.Deserialize<ImportModel>(jsonReader);
                    }
                }
            }

            return importModel;
        }

        public static MatchScoutingData2014 GetMatch(Dictionary<int, MatchScoutingData2014> matches, int matchNumber)
        {
            if (!matches.ContainsKey(matchNumber))
            {
                matches.Add(matchNumber, new MatchScoutingData2014());
            }
            return matches[matchNumber];
        }

        public static void ImportSchedule(Competition competition, ImportModel matchData)
        {
            foreach (var matchSchedule in matchData.Matches)
            {
                if (competition.Matches.Any(m => m.MatchNumber == matchSchedule.Key))
                {
                    continue;
                }

                var match = new Match();
                match.MatchNumber = matchSchedule.Key;
                match.Blue1 = GetTeam(competition, matchSchedule.Value.Blue1);
                match.Blue2 = GetTeam(competition, matchSchedule.Value.Blue2);
                match.Blue3 = GetTeam(competition, matchSchedule.Value.Blue3);
                match.Red1 = GetTeam(competition, matchSchedule.Value.Red1);
                match.Red2 = GetTeam(competition, matchSchedule.Value.Red2);
                match.Red3 = GetTeam(competition, matchSchedule.Value.Red3);

                competition.Matches.Add(match);
            }
        }

        public static void ImportMatchData(Competition competition, ImportModel matchData)
        {
            foreach (var rawTeam in matchData.Teams)
            {
                var team = GetTeam(competition, rawTeam.Key);
                if (rawTeam.Value.Matches == null)
                {
                    continue;
                }

                foreach (var rawMatch in rawTeam.Value.Matches)
                {
                    var match = team.MatchData2014.FirstOrDefault(m => m.MatchNumber == rawMatch.Key);
                    if (match == null)
                    {
                        match = new MatchScoutingData2014();
                        match.MatchNumber = rawMatch.Key;
                        team.MatchData2014.Add(match);
                    }

                    // autonomous
                    match.AutonomousHigh = rawMatch.Value.AutonomousHigh;
                    match.AutonomousHighHot = rawMatch.Value.AutonomousHighHot;
                    match.AutonomousLow = rawMatch.Value.AutonomousLow;
                    match.AutonomousLowHot = rawMatch.Value.AutonomousLowHot;
                    match.Mobility = rawMatch.Value.Mobility == "yes";
                    
                    // overall
                    switch (rawMatch.Value.StartingPosition)
                    {
                        case "side":
                            match.StartingPosition = StartingPosition.Side;
                            break;
                        case "middle":
                            match.StartingPosition = StartingPosition.Middle;
                            break;
                        case "goalie":
                            match.StartingPosition = StartingPosition.Goalie;
                            break;
                    }
                    match.Fouls = rawMatch.Value.Fouls.GetValueOrDefault() + rawMatch.Value.Technicals.GetValueOrDefault();

                    // possession
                    match.TeleOperatedPossessionFront = rawMatch.Value.TeleOperatedPossessionFront;
                    match.TeleOperatedPossessionMiddle = rawMatch.Value.TeleOperatedPossessionMiddle;
                    match.TeleOperatedPossessionBack = rawMatch.Value.TeleOperatedPossessionBack;

                    // offense
                    match.TeleOperatedTruss = rawMatch.Value.TeleOperatedTruss;
                    match.TeleOperatedCatch = rawMatch.Value.TeleOperatedCatch;
                    match.TeleOperatedCatchFail = rawMatch.Value.TeleOperatedCatchFail;
                    match.TeleOperatedHighGoal = rawMatch.Value.TeleOperatedHighGoal;
                    match.TeleOperatedHighGoalMiss = rawMatch.Value.TeleOperatedHighGoalMiss;
                    match.TeleOperatedLowGoal = rawMatch.Value.TeleOperatedLowGoal;

                    // ball control
                    match.TeleOperatedBallsLost = rawMatch.Value.TeleOperatedBallsLost;

                    // defense
                    match.ShotsDefended = rawMatch.Value.ShotsDefended;
                    match.DefensiveContacts = rawMatch.Value.DefensiveContacts;
                    match.PinnedOpponents = rawMatch.Value.PinnedOpponents;
                    
                    // comments
                    match.ManuverabilityComments = rawMatch.Value.ManuverabilityComments;
                    match.CollectorComments = rawMatch.Value.CollectorComments;
                    
                    match.ShooterComments = rawMatch.Value.ShooterComments;
                    match.OverallComments = rawMatch.Value.OverallComments;
                }
            }
        }

        private static Team GetTeam(Competition competition, int number)
        {
            var team = competition.Teams.SingleOrDefault(t => t.Number == number);
            if (team == null)
            {
                team = new Team { Number = number };
                competition.Teams.Add(team);
            }
            return team;
        }
    }
}
