using CuentasDiarias.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Infrastructure.Interface
{
	public interface IRolesRepository
	{
		IEnumerable<Roles> GetRolesUserByIdUser(int Id);
	}
}
