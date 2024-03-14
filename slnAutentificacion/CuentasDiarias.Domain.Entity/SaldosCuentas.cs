using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public class SaldosCuentas
    {
        public int Id { get; set; } 
        public float MontoInicial { get; set; }
        public float MontoUtilizado  { get; set; }
        public float MontoDisponible { get; set; }

        public float MontoContable { get; set; }    

        public int CuentaId { get; set; }
    }
}
