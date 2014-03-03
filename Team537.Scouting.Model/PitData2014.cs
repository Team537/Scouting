using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    public class PitData2014 : NotifyObject
    {
        private DriveTrainType driveTrainType;

        private string comments;

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
