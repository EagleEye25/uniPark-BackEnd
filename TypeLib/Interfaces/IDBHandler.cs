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
        DataTable BLL_GetPersonel();
        bool BLL_AddPersonel(string PersonelID, string PersonelTagNumber, string PersonelPassword, string PersonelSurname, string PersonelName, string PersonelPhoneNumber, string PersonelEmail, int PersonelLevelID, int PersonelTypeID);
        DataTable BLL_GetLevels();
        DataTable BLL_GetTypes();
        uspGetAllInfo BLL_getallinfo(string userid);
        bool BLL_EditPersonel(string name, string id, string surname, string email, int level, int type);
        List<uspCheckGuest> BLL_checkguest(string guest);
        bool BLL_addguest(string PersonelID, string PersonelPassword, string PersonelSurname, string PersonelName, string PersonelPhoneNumber, string PersonelEmail, int PersonelLevelID);   	
        DataTable BLL_GetAllInfo(string id);
        bool BLL_deleteuser(string userid);

        bool BLL_AddParkingArea(ParkingArea PA);
        bool BLL_AddPakingSpace(string ParkingType, string ParkingAreaID);

    }

}
