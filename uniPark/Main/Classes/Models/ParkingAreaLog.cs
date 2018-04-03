using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uniPark.Main.Classes.Models
{
    /* Model class for ParkingAreaLog*/
    public class ParkingAreaLog
    {
        public int AreaLogID { get; set; }
        public DateTime AreaLoginTime { get; set; }
        public DateTime? AreaLogoutTime { get; set; }
        public int PersonelLogID { get; set; }
        public string ParkingAreaID { get; set; }
    }
}
