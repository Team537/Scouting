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
                this.OnPropertyChanged("TractionWheel");
                this.OnPropertyChanged("OmniWheel");
                this.OnPropertyChanged("MecanumWheel");
                this.OnPropertyChanged("Treads");
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

        public bool TractionWheel
        {
            get
            {
                return (this.team.PitData2014.WheelType & WheelType.Traction) == WheelType.Traction;
            }
            set
            {
                this.SetWheelType(WheelType.Traction, value);
                this.OnPropertyChanged();
            }
        }

        public bool OmniWheel
        {
            get
            {
                return (this.team.PitData2014.WheelType & WheelType.Omni) == WheelType.Omni;
            }
            set
            {
                this.SetWheelType(WheelType.Omni, value);
                this.OnPropertyChanged();
            }
        }

        public bool MecanumWheel
        {
            get
            {
                return (this.team.PitData2014.WheelType & WheelType.Mecanum) == WheelType.Mecanum;
            }
            set
            {
                this.SetWheelType(WheelType.Mecanum, value);
                this.OnPropertyChanged();
            }
        }

        public bool Treads
        {
            get
            {
                return (this.team.PitData2014.WheelType & WheelType.Treads) == WheelType.Treads;
            }
            set
            {
                this.SetWheelType(WheelType.Treads, value);
                this.OnPropertyChanged();
            }
        }

        private void SetWheelType(WheelType wheel, bool set)
        {
            if (set)
            {
                this.team.PitData2014.WheelType |= wheel;
            }
            else
            {
                this.team.PitData2014.WheelType &= ~wheel;
            }
        }

        private DriveTrainType[] driveTrainTypes;

        public DriveTrainType[] DriveTrainTypes
        {
            get
            {
                if (driveTrainTypes != null && driveTrainTypes.Any())
                {
                    return driveTrainTypes;
                }

                var values = new List<DriveTrainType>();
                foreach (var value in Enum.GetValues(typeof(DriveTrainType)))
                {
                    values.Add((DriveTrainType)value);
                }

                driveTrainTypes = values.ToArray();

                return driveTrainTypes;
            }
        }

        private RobotSide[] robotSides;

        public RobotSide[] RobotSides
        {
            get
            {
                if (robotSides != null && robotSides.Any())
                {
                    return robotSides;
                }

                var values = new List<RobotSide>();
                foreach (var value in Enum.GetValues(typeof(RobotSide)))
                {
                    values.Add((RobotSide)value);
                }

                robotSides = values.ToArray();

                return robotSides;
            }
        }
    }
}
