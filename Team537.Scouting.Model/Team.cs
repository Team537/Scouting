using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Team537.Scouting.Model
{
    using Newtonsoft.Json;

    public class Team : NotifyObject
    {
        [JsonIgnore]
        public Competition Competition { get; set; }

        private int number;

        private string name;

        private string imagePath;

        private MatchSummaryData2014 matchSummaryData;

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (value == this.number)
                {
                    return;
                }
                this.number = value;
                this.OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == this.name)
                {
                    return;
                }
                this.name = value;
                this.OnPropertyChanged();
            }
        }

        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
            set
            {
                if (value == this.imagePath)
                {
                    return;
                }
                this.imagePath = value;
                this.OnPropertyChanged();
            }
        }
        
        public PitData2014 PitData2014 { get; set; }

        public ObservableCollection<MatchScoutingData2014> MatchData2014 { get; private set; }

        [JsonIgnore]
        public MatchSummaryData2014 MatchSummaryData
        {
            get
            {
                return this.matchSummaryData;
            }
            set
            {
                if (Equals(value, this.matchSummaryData))
                {
                    return;
                }
                this.matchSummaryData = value;
                this.OnPropertyChanged();
            }
        }

        public Team()
        {
            MatchData2014 = new ObservableCollection<MatchScoutingData2014>();
            PitData2014 = new PitData2014();
        }
    }
}
