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
    public class DBAccess:IDBAccess
    {
        
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
    }
}
