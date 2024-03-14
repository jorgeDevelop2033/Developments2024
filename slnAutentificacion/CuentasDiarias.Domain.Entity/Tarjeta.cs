using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string NroTarjeta { get; set; } = null;
        public string NombreTarjeta { get; set; } = null;
        public short Tipo { get; set; }
        public int CuentaId { get; set; } 
    }
}
