using System;
using System.Collections.Generic;
using System.Text;

namespace CCALearn.TruckLib
{
    public class Pickup: Truck
    {
        public string BedType { get; set; }

        public int Drive { get; set; }  // 2WD or 4WD, i.e. the number 2 or 4 should be here
    }
}
