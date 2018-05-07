using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class ParkingArea
    {
        public string ParkingAreaID { get; set; }
        public string ParkingAreaName { get; set; }
        public string ParkingAreaLocation { get; set; }
        public int? ParkingAreaAccessLevel { get; set; }
    }
}