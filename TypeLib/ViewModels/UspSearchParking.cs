using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class UspSearchParking
    {
        public string Parkingspaceid { get; set; }
        public string Location { get; set; }
        public bool? Available { get; set; }
        public Single? Fee { get; set; }
    }
}
