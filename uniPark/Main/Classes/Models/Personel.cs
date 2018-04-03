using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uniPark.Main.Classes.Models
{
    /* Model class for Personel*/
    public class Personel
    {
        public string PersonelID { get; set; }
        public string PersonelTagNumber { get; set; }
        public string Password { get; set; }
        public string PersonelSurname { get; set; }
        public string PersonelName { get; set; }
        public string PersonelPhoneNumber { get; set; }
        public string PersonelEmail { get; set; }
        public int PersonelLevelID { get; set; }
        public int PersonelTypeID { get; set; }
    }
}
