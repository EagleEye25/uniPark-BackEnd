using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.Models;
using TypeLib.ViewModels;
using TypeLib.Interfaces;
using uniPark_DAL;
using System.Data;


namespace uniPark_BLL
{
    public class DBHandler : IDBHandeler
    {
        private IDBAccess db;

        public DBHandler()
        {
            db = new DBAccess();

        }


        public DataTable BLL_GetParkingAreas()
        {
          return  db.GetParkingAreas();
        }
        public DataTable BLL_GetParkingSpaces(string parkinngAreaID)
        {
            return db.GetParkingSpaces(parkinngAreaID);
        }
        public DataTable BLL_SearchParkingSpaceDetails(string parkingAreaID, string parkingSpaceID)
        {
            return db.SearchParkingSpaceDetails(parkingAreaID,parkingSpaceID);
        }

    }
}
