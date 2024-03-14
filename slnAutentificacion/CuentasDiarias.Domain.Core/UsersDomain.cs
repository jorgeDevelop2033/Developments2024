using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Domain.Interface;
using CuentasDiarias.Infrastructure.Interface;

namespace CuentasDiarias.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }

		public bool InsertUsers(Users users)
		{
            return _usersRepository.InsertUsers(users);
		}
	}
}
