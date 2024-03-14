using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public   class Pagos
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public int ServicioId { get; set; }
        public float Monto { get; set; }
    }
}
