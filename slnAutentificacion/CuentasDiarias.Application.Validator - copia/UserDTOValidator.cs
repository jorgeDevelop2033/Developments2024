using FluentValidation;
using CuentasDiarias.Application.DTO;

namespace CuentasDiarias.Application.Validator
{
    public class UserDTOValidator :AbstractValidator<UsersDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }


    }
}