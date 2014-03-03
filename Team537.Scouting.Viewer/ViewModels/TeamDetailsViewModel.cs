using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.ViewModels
{
    using Windows.UI.Xaml.Media.Imaging;

    using Team537.Scouting.Model;

    public class TeamDetailsViewModel : NotifyObject
    {
        private Team team;

        private BitmapImage teamImage;

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

        public BitmapImage TeamImage
        {
            get
            {
                return this.teamImage;
            }
            set
            {
                if (Equals(value, this.teamImage))
                {
                    return;
                }
                this.teamImage = value;
                this.OnPropertyChanged();
            }
        }
    }
}
