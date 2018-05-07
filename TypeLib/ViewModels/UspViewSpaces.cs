using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class UspViewSpaces
    {
        public string ParkingSpaceID { get; set; }
        public string ParkingType { get; set; }
        public bool? Available { get; set; }
        public string ParkingAreaID { get; set; }
        public int? ParkingFeeID { get; set; }
    }
}
