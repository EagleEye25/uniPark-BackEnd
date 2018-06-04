﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TypeLib.Interfaces;
using TypeLib.Models;
using TypeLib.ViewModels;
using uniPark_DAL;

namespace uniPark_DAL
{
   public class DBAccess : IDBAccess
    {
        //get parking area details
        public DataTable GetParkingAreas()
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
                public uspLogin Login(string userID)
        {
            uspLogin l = null;
            SqlParameter[] pars = new SqlParameter[]
                {
                    new SqlParameter("@Username", userID),
                };

            using (DataTable table = DBHelper.ParamSelect("uspLogin",
            CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    l = new uspLogin
                    {
                        PersonelPassword = Convert.ToString(row["PersonelPassword"])
                    };

                }
            }
            return l;
        }//EndLogin

        public bool AddPersonel(string PersonelID,string PersonelTagNumber,string PersonelPassword,string PersonelSurname
            ,string PersonelName,string PersonelPhoneNumber,string PersonelEmail,int PersonelLevelID,int PersonelTypeID)
        {

            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@PersonelID", PersonelID),
                    new SqlParameter("@PersonelTagNumber",PersonelTagNumber),
                    new SqlParameter("@PersonelPassword",PersonelPassword),
                    new SqlParameter("@PersonelSurname",PersonelSurname),
                    new SqlParameter("@PersonelName",PersonelName),
                    new SqlParameter("@PersonelPhoneNumber",PersonelPhoneNumber),
                    new SqlParameter("@PersonelEmail",PersonelEmail),
                    new SqlParameter("@PersonelLevelID",PersonelLevelID),
                    new SqlParameter("@PersonelTypeID",PersonelTypeID)
            };
            return DBHelper.NonQuery("uspAddPersonel", CommandType.StoredProcedure, pars);
   
        }

        public DataTable GetLevels()
        {
            DataTable dt = new DataTable();

            dt = DBHelper.Select("uspGetlevels", CommandType.StoredProcedure);
            return dt;

        }
        public DataTable GetTypes()
        {
            DataTable dt = new DataTable();

            dt = DBHelper.Select("uspGetTypes", CommandType.StoredProcedure);
            return dt;

        }


    }
}

