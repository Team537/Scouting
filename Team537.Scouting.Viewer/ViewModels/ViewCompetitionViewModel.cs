using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.ViewModels
{
    using Team537.Scouting.Model;

    public class ViewCompetitionViewModel : NotifyObject
    {
        private Competition competition;

        public Competition Competition
        {
            get
            {
                return this.competition;
            }
            set
            {
                if (Equals(value, this.competition))
                {
                    return;
                }
                this.competition = value;
                this.OnPropertyChanged();
            }
        }
    }
}
