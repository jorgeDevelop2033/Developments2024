using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal MontoMaximoPago { get; set; }
        public short DiaPago { get; set; }
        public int NumeroServicio { get; set; }
        public bool EsPagoAutomatico { get; set; }
        public short TipoPago { get; set; }
    }
}
