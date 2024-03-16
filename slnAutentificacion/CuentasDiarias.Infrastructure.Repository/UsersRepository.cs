using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Infrastructure.Data;
using CuentasDiarias.Infrastructure.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CuentasDiarias.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public readonly DapperContext _dapperContext;

        public UsersRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sp = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters(); //libreria Dapper

                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(sp, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                return user;
            }
        }

        public bool InsertUsers(Users users)
        {
            try
            {

                using (var connection = _dapperContext.CreateConnection())
                {
                    var sp = "UserInsert";
                    var parameters = new DynamicParameters(); //libreria Dapper

                    parameters.Add("FirstName", users.FirstName);
                    parameters.Add("LastName ", users.LastName);
                    parameters.Add("UserName", users.UserName);
                    parameters.Add("Password", users.Password);

                    var user = connection.Query<Users>(sp, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return false;
            }
        }
    }
}
