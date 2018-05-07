using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.Models;
using TypeLib.ViewModels;
using TypeLib.Interfaces;
using uniPark_DAL;


namespace uniPark_BLL
{
    public class DBHandler : IDBHandeler
    {
        private IDBAccess db;

        public DBHandler()
        {
            db = new DBAccess();
        }



    }
}
