using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.ViewModels
{
    using System.Collections.ObjectModel;

    using Team537.Scouting.Model;

    public class TeamHubViewModel : NotifyObject
    {
        private Team team;

        public Team Team
        {
            get
            {
                return this.team;
            }
            set
            {
                if (Equals(value, this.team))
                {
                    return;
                }
                this.team = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Match> Schedule { get; private set; }

        public TeamHubViewModel()
        {
            Schedule = new ObservableCollection<Match>();
        }
    }
}
