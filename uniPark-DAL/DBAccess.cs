using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TypeLib.Interfaces;
using TypeLib.Models;
using TypeLib.ViewModels;

namespace uniPark_DAL
{
   public class DBAccess : IDBAccess
    {
        //get parking area details
        public DataTable GetParingAreas()
        {


            DataTable dt = DBHelper.Select("uspGetParkingAreas", CommandType.StoredProcedure);
            /* {
                 if(dt.Rows.Count > 0)
                 {
                     foreach (DataRow row  in dt.Rows)
                     {
                         uspGetParkingAreas pa = new uspGetParkingAreas();
                         pa = new uspGetParkingAreas();
                         pa.ParkingAreaAccessLevel = Convert.ToInt32(row["ParkingAreaAccessLevel"]);
                         pa.ParkingAreaName = Convert.ToString(row["ParkingAreaName"]);
                         pa.ParkingAreaLocation = Convert.ToString(row["ParkingAreaLocation"]);
                     }
                 }
           } */
            return dt;
        }
        // Get All ParkingSpaces accociated with parkingArea
        public DataTable GetParkingSpaces(string parkingAreaID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("ParkingAreaID",parkingAreaID),

            };

            dt = DBHelper.ParamSelect("uspGetAllSpecificSpaces", CommandType.StoredProcedure, pars);

            return dt;
        }
        //Search parkingSpace details
        public DataTable SearchParkingSpaceDetails(string parkingAreaID, string parkingSpaceID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("ParkingAreaID",parkingAreaID),
                new SqlParameter("ParkingSpaceID",parkingSpaceID),

            };

            dt = DBHelper.ParamSelect("uspSearchParking", CommandType.StoredProcedure, pars);

            return dt;
        }


    }
}

