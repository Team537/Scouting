using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Model
{
    [Flags]
    public enum WheelType
    {
        Traction = 1,
        Omni = 2,
        Mecanum = 4,
        Treads = 8
    }
}
