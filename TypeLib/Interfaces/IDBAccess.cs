using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.ViewModels;
using TypeLib.Models;

namespace TypeLib.Interfaces
{
    public interface IDBAccess
    {
        uspLogin Login(string userID);
    }
}
