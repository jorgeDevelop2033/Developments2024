using AutoMapper;
using CuentasDiarias.Application.DTO;
using CuentasDiarias.Domain.Entity;

namespace CuentasDiarias.Transversal.Mapper
{
	public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            //Automatico ya que los campos son iguales
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<Roles, RolesDTO>().ReverseMap();
        }
    }
}