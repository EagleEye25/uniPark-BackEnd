using System;
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
                        PersonnelPassword = Convert.ToString(row["PersonnelPassword"])
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
        public DataTable GetPersonel()
        {
            DataTable dt = new DataTable();
            dt = DBHelper.Select("uspDisplayPersonelInfoAll", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable GetAllInfo(string id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@personelid", id) };
            dt = DBHelper.ParamSelect("uspGetAllInfo", CommandType.StoredProcedure,pars);
            return dt;
        }

        public uspGetAllInfo getallinfo(string userid)
        {
            uspGetAllInfo i = null;
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@personelid", userid)};

            using (DataTable table = DBHelper.ParamSelect("uspGetAllInfo",
            CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    i = new uspGetAllInfo
                    {        
                        PersonnelID = Convert.ToString(row["PersonnelID"]),
                        PersonnelTagNumber = Convert.ToString(row["PersonnelTagNumber"]),
                        PersonnelPassword = Convert.ToString(row["PersonnelPassword"]),
                        PersonnelSurname = Convert.ToString(row["PersonnelSurname"]),
                        PersonnelName = Convert.ToString(row["PersonnelName"]),
                        PersonnelPhoneNumber = Convert.ToString(row["PersonnelPhoneNumber"]),
                        PersonnelEmail = Convert.ToString(row["PersonnelEmail"]),
                        PersonnelLevelID = Convert.ToInt32(row["PersonnelLevelID"]),
                        PersonnelTypeID = Convert.ToInt32(row["PersonnelTypeID"]),
                    };

                }
            }
            return i;
        }
        public bool EditPersonel(string name, string id, string surname, string email, int level, int type)
        {
            SqlParameter[] pars = new SqlParameter[]
                {
                    new SqlParameter("@name", name),
                    new SqlParameter("@id",id),
                    new SqlParameter("@surname",surname),
                    new SqlParameter("@email",email),
                    new SqlParameter("@level",level),
                    new SqlParameter("@type",type)
                };
            return DBHelper.NonQuery("uspUpdatePersonnel", CommandType.StoredProcedure, pars);
        }

        public List<uspCheckGuest> checkguest(string guest)
        {
            List<uspCheckGuest> list = new List<uspCheckGuest>();
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@guest", guest)
            };

            using (DataTable dt = DBHelper.ParamSelect("uspCheckGuest", CommandType.StoredProcedure, pars))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        uspCheckGuest g = new uspCheckGuest
                        {
                            PersonnelID = Convert.ToString(row["PersonnelID"])
                        };
                        list.Add(g);
                    }

                }
                else { list = null; }
            }
            return list;
        }

        public bool addguest(string PersonelID, string PersonelPassword, string PersonelSurname, string PersonelName, string PersonelPhoneNumber, string PersonelEmail, int PersonelLevelID)
        {
            SqlParameter[] pars = new SqlParameter[]
                {
                    new SqlParameter("@PersonelID", PersonelID),
                    new SqlParameter("@PersonelPassword",PersonelPassword),
                    new SqlParameter("@PersonelSurname",PersonelSurname),
                    new SqlParameter("@PersonelName",PersonelName),
                    new SqlParameter("@PersonelPhoneNumber",PersonelPhoneNumber),
                    new SqlParameter("@PersonelEmail",PersonelEmail),
                    new SqlParameter("@PersonelLevelID",PersonelLevelID)
                    
                };
            return DBHelper.NonQuery("uspAddGuest", CommandType.StoredProcedure, pars);

        }
        public bool deleteuser(string userid)
        {
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@id", userid),

            };
            return DBHelper.NonQuery("uspDeletePersonel", CommandType.StoredProcedure, pars);
        }
        public bool AddParkingArea(ParkingArea PA)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in PA.GetType().GetProperties())
            {
                if (prop.GetValue(PA) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(PA)));
                }
            }
            return DBHelper.NonQuery("uspAddParkingArea", CommandType.StoredProcedure,
                parameters.ToArray());
        }
        public bool AddPakingSpace(string ParkingType,string ParkingAreaID)
        {
            SqlParameter[] pars = new SqlParameter[]
           {
                    new SqlParameter("@ParkingType", ParkingType),
                    new SqlParameter("@ParkingAreaID",ParkingAreaID),
                   
                   
           };
            return DBHelper.NonQuery("uspAddSpace", CommandType.StoredProcedure, pars);

        }

    }

}


