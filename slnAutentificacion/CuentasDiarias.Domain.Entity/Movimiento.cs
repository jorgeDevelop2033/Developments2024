using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity
{
    public class Movimiento
    {
        public int Id { get; set; } 
        public DateTime FechaMovimiento { get; set; }
        public  int TipoMovimientoId { get; set; }
        public int CuentaOrigenId { get; set; }
        public int CuentaDestinoId { get; set; }
        public float Monto { get; set; }
        public int ItemId { get; set; }
        public int TarjetaId { get; set; }
        public short NroCuotas { get; set; }
        public string DescripcionMovimiento { get; set; }
        public int ServicioId { get; set; }
        public string Descripcion { get; set; }

        //si el el itemId es un pago de servicio 
        //agregar un nuevo valor en otra tabla
        //id MOvimiento - IdServicio
    }
}
