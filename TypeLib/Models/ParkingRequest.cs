using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class ParkingRequest
    {
        public int ParkingRequestID { get; set; }
        public DateTime? ParkingRequestTime { get; set; }
        public string PersonelID { get; set; }
        public string ParkingSpaceID { get; set; }
    }
}
