using CuentasDiarias.Domain.Entity;

namespace CuentasDiarias.Domain.Interface
{
	public interface IRolesDomain
	{
		IEnumerable<Roles> GetRolesUsersById(int Id);
	}
}
