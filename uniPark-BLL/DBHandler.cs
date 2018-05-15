using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.Interfaces;
using TypeLib.Models;
using TypeLib.ViewModels;
using uniPark_DAL;

namespace uniPark_BLL
{
    public class DBHandler:IDBHandler 
    {
        private IDBAccess db;

        public DBHandler()
        {
            db = new DBAccess();
        }

        public uspLogin BLL_Login(string userid)
        {
            return db.Login(userid);
        }


    }
}
