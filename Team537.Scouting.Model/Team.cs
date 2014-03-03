using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Team537.Scouting.Model
{
    public class Team : NotifyObject
    {
        private int number;

        private string name;

        private string imagePath;

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

        public Team()
        {
            MatchData2014 = new ObservableCollection<MatchScoutingData2014>();
            PitData2014 = new PitData2014();
        }
    }
}
