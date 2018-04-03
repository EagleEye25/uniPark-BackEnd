using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uniPark.Main.Classes.Database.ViewModels
{
    /* View Model class for uspSearchParking*/
    public class uspSearchParking
    {
        public string ParkingSpaceID { get; set; }
        public string Location { get; set; }
        public bool Available { get; set; }
        public decimal Fee { get; set; }
    }
}
