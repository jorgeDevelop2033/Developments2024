using AutoMapper;
using CuentasDiarias.Application.DTO;
using CuentasDiarias.Application.Interface;
using CuentasDiarias.Domain.Interface;
using CuentasDiarias.Transversal.Common;

namespace CuentasDiarias.Application.Main
{
	public class RolesApplication : IRolesApplication
	{
		public readonly IRolesDomain _rolesDomain;
		public readonly IMapper _mapper;

		public RolesApplication(IRolesDomain rolesDomain, IMapper mapper)
		{
			_rolesDomain = rolesDomain;
			_mapper = mapper;
		}

		public Response<IEnumerable<RolesDTO>> GetRolesUsersById(int Id)
		{
			var response = new Response<IEnumerable<RolesDTO>>();
		 
			try
			{
				var roles = _rolesDomain.GetRolesUsersById(Id);

				response.Data = _mapper.Map<List<RolesDTO>>(roles);
				response.IsSuccess = true;
				response.Message = "Obtencion Roles Exitosa!";
			}
			catch (InvalidOperationException)
			{
				response.IsSuccess = true;
				response.Message = "Roles No existe";
			}
			catch (Exception ex)
			{
				response.Message = ex.Message;
			}

			return response;
		}
	}
}
