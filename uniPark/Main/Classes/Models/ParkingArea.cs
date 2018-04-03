using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uniPark.Main.Classes.Models
{
    /* Model class for ParkingArea*/
    public class ParkingArea
    {
        public string ParkingAreaID { get; set; }
        public string ParkingAreaName { get; set; }
        public string ParkingAreaLocation { get; set; }
        public int AreaAccessLevel { get; set; }
    }
}
