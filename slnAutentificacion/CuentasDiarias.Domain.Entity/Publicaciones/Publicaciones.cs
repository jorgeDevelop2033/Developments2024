using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDiarias.Domain.Entity.Publicaciones
{
    public class Publicacione
    {
        public Publicacione() { }
        public int Id { get; set; }
        public string CodigoContenedor { get; set; }
        public string Publicacion { get; set; }
        public string FechaPublicacion { get; set; }
    }
}
