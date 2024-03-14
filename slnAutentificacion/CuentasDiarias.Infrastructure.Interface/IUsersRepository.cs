using CuentasDiarias.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Infrastructure.Interface
{
    public  interface IUsersRepository
    {
        Users Authenticate(string username, string password);
        bool InsertUsers(Users users);
    }
}
