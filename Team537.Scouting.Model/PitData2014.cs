using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    using System.Runtime.InteropServices.WindowsRuntime;

    public class PitData2014 : NotifyObject
    {
        private DriveTrainType driveTrainType;

        private string comments;

        private string size;

        private RobotSide collectorSide;

        private RobotSide shooterSide;

        private WheelType wheelType;

        private bool goalieArm;

        private string goalieDescription;

        public DriveTrainType DriveTrainType
        {
            get
            {
                return this.driveTrainType;
            }
            set
            {
                if (value == this.driveTrainType)
                {
                    return;
                }
                this.driveTrainType = value;
                this.OnPropertyChanged();
            }
        }

        public string Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value == this.size)
                {
                    return;
                }
                this.size = value;
                this.OnPropertyChanged();
            }
        }

        public RobotSide CollectorSide
        {
            get
            {
                return this.collectorSide;
            }
            set
            {
                if (value == this.collectorSide)
                {
                    return;
                }
                this.collectorSide = value;
                this.OnPropertyChanged();
            }
        }

        public RobotSide ShooterSide
        {
            get
            {
                return this.shooterSide;
            }
            set
            {
                if (value == this.shooterSide)
                {
                    return;
                }
                this.shooterSide = value;
                this.OnPropertyChanged();
            }
        }

        public WheelType WheelType
        {
            get
            {
                return this.wheelType;
            }
            set
            {
                if (value == this.wheelType)
                {
                    return;
                }
                this.wheelType = value;
                this.OnPropertyChanged();
            }
        }

        public bool GoalieArm
        {
            get
            {
                return this.goalieArm;
            }
            set
            {
                if (value.Equals(this.goalieArm))
                {
                    return;
                }
                this.goalieArm = value;
                this.OnPropertyChanged();
            }
        }

        public string GoalieDescription
        {
            get
            {
                return this.goalieDescription;
            }
            set
            {
                if (value == this.goalieDescription)
                {
                    return;
                }
                this.goalieDescription = value;
                this.OnPropertyChanged();
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                if (value == this.comments)
                {
                    return;
                }
                this.comments = value;
                this.OnPropertyChanged();
            }
        }
    }
}
