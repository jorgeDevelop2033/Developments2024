using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string NombreCuenta { get; set; }
        public string NombrePersona { get; set; }

        public string NroCuenta { get; set; }
        public int TipoCuentaId { get; set; }
        public int BancoId { get; set; }
        public int UserId { get; set; }
    }
}
