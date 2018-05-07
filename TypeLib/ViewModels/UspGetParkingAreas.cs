using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class UspGetParkingAreas
    {
        public string ParkingAreaID { get; set; }
        public string ParkingAreaName { get; set; }
        public string ParkingAreaLocation { get; set; }
        public int? ParkingAreaAccessLevel { get; set; }
    }
}
