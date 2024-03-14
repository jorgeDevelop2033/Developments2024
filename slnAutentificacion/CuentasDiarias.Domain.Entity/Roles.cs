using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
	public class Roles
	{
		public int IdRoles { get; set; }
		public string Nombre { get; set; }
		public string TipoRol { get; set; }
		public string Routes { get; set; }
	}
}
