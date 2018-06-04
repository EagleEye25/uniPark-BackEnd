using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.Models;
using TypeLib.ViewModels;
using System.Data;

namespace TypeLib.Interfaces
{
    public interface IDBHandler
    {
        DataTable BLL_GetParkingAreas();
        DataTable BLL_GetParkingSpaces(string parkinngAreaID);
        DataTable BLL_SearchParkingSpaceDetails(string parkingAreaID, string parkingSpaceID);
        uspLogin BLL_Login(string userID);
        bool BLL_AddPersonel(string PersonelID, string PersonelTagNumber, string PersonelPassword, string PersonelSurname, string PersonelName, string PersonelPhoneNumber, string PersonelEmail, int PersonelLevelID, int PersonelTypeID);
        DataTable BLL_GetLevels();
        DataTable BLL_GetTypes();
    }
}
