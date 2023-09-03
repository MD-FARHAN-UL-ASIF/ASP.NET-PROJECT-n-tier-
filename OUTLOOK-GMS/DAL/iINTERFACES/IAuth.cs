using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iINTERFACES
{
    public interface IAuth
    {
        Employee Authenticate(string email, string password);
    }
}
