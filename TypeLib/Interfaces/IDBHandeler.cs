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
    public interface IDBHandeler
    {
        DataTable BLL_GetParkingAreas();
        DataTable BLL_GetParkingSpaces(string parkinngAreaID);
        DataTable BLL_SearchParkingSpaceDetails(string parkingAreaID, string parkingSpaceID);
    }
}
