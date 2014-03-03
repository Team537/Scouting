using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    using System.Collections.ObjectModel;

    public class Competition : NotifyObject
    {
        private string name;

        private string location;

        private string imagePath;

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

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (value == this.location)
                {
                    return;
                }
                this.location = value;
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

        public ObservableCollection<Match> Matches { get; private set; }

        public ObservableCollection<Team> Teams { get; private set; }

        public Competition()
        {
            Matches = new ObservableCollection<Match>();
            Teams = new ObservableCollection<Team>();
        }
    }
}
