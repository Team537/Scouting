using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.ViewModels
{
    using Team537.Scouting.Model;

    public class ViewMatchViewModel : NotifyObject
    {
        private Match match;

        public Match Match
        {
            get
            {
                return this.match;
            }
            set
            {
                if (Equals(value, this.match))
                {
                    return;
                }
                this.match = value;
                this.OnPropertyChanged();
            }
        }
    }
}
