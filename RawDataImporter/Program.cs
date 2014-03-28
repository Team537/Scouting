using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawDataImporter
{
    using System.IO;
    using System.Net.Http;

    using Newtonsoft.Json;

    using Team537.Scouting.Model.Import;

    class Program
    {
        static void Main(string[] args)
        {
            var importModel = new ImportModel();

            //var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            //var file = await folder.GetFileAsync("matches.json");

            var client = new HttpClient();
            var uri = new Uri("http://10.5.3.7/scouting/json/flat.php", UriKind.Absolute);
            using (var downloadStream = client.GetStreamAsync(uri).Result)
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

            using (var dbContext = new RawDataDbContext())
            {
                foreach (var team in importModel.Teams)
                {
                    var matches = team.Value.Matches;
                    if (matches == null)
                    {
                        continue;
                    }

                    foreach (var match in matches)
                    {
                        Console.Write("{0} {1}", team.Key, match.Key);
                        var importantMatchData = new ImportantMatchData();
                        importantMatchData.MatchNumber = match.Key;
                        importantMatchData.AutonomousHighMade = match.Value.AutonomousHigh
                                                                + match.Value.AutonomousHighHot;
                        importantMatchData.BallsDropped = match.Value.TeleOperatedBallsLost.GetValueOrDefault();
                        importantMatchData.Catches = match.Value.TeleOperatedCatch;
                        importantMatchData.HighGoals = match.Value.TeleOperatedHighGoal;
                        importantMatchData.HighGoalsAttempted = match.Value.TeleOperatedHighGoal
                                                                + match.Value.TeleOperatedHighGoalMiss;
                        importantMatchData.TeamNumber = team.Key;
                        importantMatchData.Possessions = match.Value.TeleOperatedPossessionBack
                                                         + match.Value.TeleOperatedPossessionFront
                                                         + match.Value.TeleOperatedPossessionMiddle;
                        importantMatchData.TrussesAttempted = match.Value.TeleOperatedTruss
                                                              + match.Value.TeleOperatedTrussFail;
                        importantMatchData.TrussesMade = match.Value.TeleOperatedTruss;

                        dbContext.Matches.Add(importantMatchData);
                        dbContext.SaveChanges();
                    }
                }
            }

        }
    }
}
