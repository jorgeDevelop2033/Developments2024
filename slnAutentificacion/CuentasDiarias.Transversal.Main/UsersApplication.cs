using AutoMapper;
using CuentasDiarias.Application.DTO;
using CuentasDiarias.Application.Interface;
using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Domain.Interface;
using CuentasDiarias.Transversal.Common;
using CuentasDiarias.Application.Validator;
using FluentValidation;

namespace CuentasDiarias.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        public readonly IUsersDomain _usersDomain;
        public readonly IMapper _mapper;
        private readonly UserDTOValidator _validationRules;
        private readonly IRolesDomain _rolesDomain;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UserDTOValidator validationRules, IRolesDomain rolesDomain)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _validationRules = validationRules;
            _rolesDomain = rolesDomain;
        }

        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            var validation = _validationRules.Validate(new UsersDTO()
            {
                UserName = username,
                Password = password
            });

            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion";
                // response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var users = _usersDomain.Authenticate(username, password);

                response.Data = _mapper.Map<UsersDTO>(users);

                var roles = _rolesDomain.GetRolesUsersById(users.UserId);

                response.Data.Roles = _mapper.Map<IEnumerable<RolesDTO>>(roles);

                response.IsSuccess = true;
                response.Message = "Autentificacion Exitosa!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario No existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<bool> InsertUsers(UsersDTO users)
        {
            var response = new Response<bool>();

            try
            {
                var entityUsers = _mapper.Map<Users>(users);

                var user = _usersDomain.InsertUsers(entityUsers);

                if (user)
                {
                    response.IsSuccess = true;
                    response.Data = true;
                    response.Message = "Usuario Registrado Correctamente!";
                }
            }
            catch (InvalidOperationException ex)
            {
                response.IsSuccess = true;
                response.Message = "Info Incorrecta!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
