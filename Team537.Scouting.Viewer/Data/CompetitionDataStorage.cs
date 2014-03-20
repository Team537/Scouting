using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.Data
{
    using Windows.Storage;

    using Newtonsoft.Json;

    using Team537.Scouting.Model;

    public static class CompetitionDataStorage
    {
        public static async Task SaveCompetition(Competition competition)
        {
            var filename = string.Format("{0}2014.json", competition.Name.Replace(" ", string.Empty));
            var data = JsonConvert.SerializeObject(competition, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, data);
        }

        public static async Task<Competition> LoadCompetition(Competition competition)
        {
            var filename = string.Format("{0}2014.json", competition.Name.Replace(" ", string.Empty));
            
            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                var data = await FileIO.ReadTextAsync(file);
                return JsonConvert.DeserializeObject<Competition>(data, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            catch (Exception)
            {
                return competition;
            }
        }
    }
}
