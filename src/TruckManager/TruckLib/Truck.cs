using System;
using System.Collections.Generic;
using System.Text;

namespace CCALearn.TruckLib
{
    public class Truck
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Manuf { get; set; }

        public int Capacity { get; set; }

        public string GetFullName()
        {
            return $"{Year} {Manuf} {Capacity}";
        }
    }
}
