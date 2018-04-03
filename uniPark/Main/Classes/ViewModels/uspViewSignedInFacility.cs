using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uniPark.Main.Classes.Database.ViewModels
{
    /* View Model class for uspViewSignedInFacility */
    public class uspViewSignedInFacility
    {
        public string PersonelID { get; set; }
        public string Name { get; set; }
        public DateTime TimeLoggedIn { get; set; }
    }
}
