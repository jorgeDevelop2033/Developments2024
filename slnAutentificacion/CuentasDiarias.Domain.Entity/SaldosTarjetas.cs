using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public class SaldosTarjetas
    {
        public int Id { get; set; }
        public float MontoUtilizado { get; set; }
        public float MontoDisponible { get; set; }
        public float MontoAsignado { get; set; }
        public int TarjetaId { get; set; }
    }
}
