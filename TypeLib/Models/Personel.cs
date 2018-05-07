using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Personel
    {
        public string PersonelID { get; set; }
        public string PersonelTagNumber { get; set; }
        public string PersonelPassword { get; set; }
        public string PersonelSurname { get; set; }
        public string PersonelName { get; set; }
        public string PersonelPhoneNumber { get; set; }
        public string PersonelEmail { get; set; }
        public int? PersonelLevelID { get; set; }
        public int? PersonelTypeID { get; set; }
    }
}
