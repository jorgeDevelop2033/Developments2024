using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Infrastructure.Data;
using CuentasDiarias.Infrastructure.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Infrastructure.Repository 
{
	public class RolesRepository : IRolesRepository
	{
		public readonly DapperContext _dapperContext;

		public RolesRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public IEnumerable<Roles> GetRolesUserByIdUser(int Id)
		{
			using (var connection = _dapperContext.CreateConnection())
			{
				var sp = "UsersRolesGetByIdUser";
				var parameters = new DynamicParameters(); //libreria Dapper

				parameters.Add("Id", Id);

				var rolesUsers = connection.Query<Roles>(sp, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

				return rolesUsers;
			}
		}
	}
}
