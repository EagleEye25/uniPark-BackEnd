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
           
            return dt;
        }

        // Get All Parking Details in Model
        public List<ParkingArea> GetAllParkingAreaDetails()
        {
            List<ParkingArea> list = new List<ParkingArea>();
            

            using (DataTable dt = DBHelper.Select("uspGetParkingAreas", CommandType.StoredProcedure))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ParkingArea PA = new ParkingArea
                        {
                            ParkingAreaID = Convert.ToString(row["ParkingAreaID"]),
                            ParkingAreaAccessLevel = Convert.ToInt32(row["ParkingAreaAccessLevel"]),
                            ParkingAreaLocation = Convert.ToString(row["ParkingAreaLocation"]),
                            ParkingAreaName = Convert.ToString(row["ParkingAreaName"]),
                            ParkingAreaCoordinates = Convert.ToString(row["ParkingAreaCoordinates"])
                            
                        };
                        list.Add(PA);
                    }

                }
                else { list = null; }
            }
            return list;
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

            using (DataTable table = DBHelper.ParamSelect("uspLoginB",
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

        public bool UpdateParkingArea(ParkingArea PA)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in PA.GetType().GetProperties())
            {
                if (prop.GetValue(PA) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(PA)));
                }
            }
            return DBHelper.NonQuery("uspUpdateParkingArea", CommandType.StoredProcedure,
                parameters.ToArray());
        }

        public bool UpdateParkingSpace(string parkingAreaID,string parkingSpaceType,int spaceID,bool available, bool status)
        {
            SqlParameter[] pars = new SqlParameter[]
              {
                    new SqlParameter("@parkingType",parkingSpaceType),
                    new SqlParameter("@parkingAreaID",parkingAreaID),
                    new SqlParameter("@parkingSpaceID",spaceID),
                    new SqlParameter("@available",available),
                    new SqlParameter("@status",status),


              };
            return DBHelper.NonQuery("uspUpdateParkingSpace", CommandType.StoredProcedure, pars);
        }




        /*

            DataTable dt = new DataTable();
            dt = DBHelper.Select("uspDisplayPersonelInfoAll", CommandType.StoredProcedure);
            return dt;
    */





        public DataTable SearchPersonnel(string name)
        {
            
            SqlParameter[] pars = new SqlParameter[]
                {
                new SqlParameter("@Name",name)
                };
            DataTable dt = DBHelper.ParamSelect("uspSearchPersonel", CommandType.StoredProcedure, pars);
            return dt;


        }
        public DataTable getInfringements(string PersonnelID)
        {
            SqlParameter[] pars = new SqlParameter[]
                {
                    new SqlParameter("PersonnelID", PersonnelID)
                };
            DataTable dt = DBHelper.ParamSelect("uspGetPersonnelReports", CommandType.StoredProcedure, pars);
            return dt;
        }



        public DataTable GetParkingRequests()
        {
            DataTable dt = new DataTable();

            dt = DBHelper.Select("uspGetParkingRequests", CommandType.StoredProcedure);
            return dt;

        }

    }

}


