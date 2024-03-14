using CuentasDiarias.Application.DTO;
using CuentasDiarias.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);

        Response<bool> InsertUsers(UsersDTO users);
    }
}
