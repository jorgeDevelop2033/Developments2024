using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Domain.Interface;
using CuentasDiarias.Infrastructure.Interface;

namespace CuentasDiarias.Domain.Core
{
	public class RolesDomain : IRolesDomain
	{
		private readonly IRolesRepository _rolesRepository;

		public RolesDomain(IRolesRepository rolesRepository)
		{
			_rolesRepository = rolesRepository;
		}

		public IEnumerable<Roles> GetRolesUsersById(int Id)
		{
			return _rolesRepository.GetRolesUserByIdUser(Id);
		}
	}
}
