using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class PersonelLog
    {
        public int PersonelLogID { get; set; }
        public DateTime? PersonelLoginTime { get; set; }
        public DateTime? PersonelLogoutTime { get; set; }
        public string PersonelID { get; set; }
        public int? MainGateID { get; set; }
        public int? LicensePlateLogID { get; set; }
    }
}
