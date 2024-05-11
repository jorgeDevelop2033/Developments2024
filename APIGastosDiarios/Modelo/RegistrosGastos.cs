using
    System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIGastosDiarios.Modelo
{
    public class RegistrosGastos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaGasto { get; set; }

        public string? ProductoId { get; set; }

        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}

