using CuentasDiarias.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Interface
{
    public interface IUsersDomain
    {
        public Users Authenticate(string username, string password);

        public bool InsertUsers(Users users);
    }
}
