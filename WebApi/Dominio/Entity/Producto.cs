using System;
using MongoDB.Bson;
using MongoDB.Entities;

namespace WebApi.Modelo
{
    [Collection("Products")]
    public class Producto
    {
        public ObjectId Id { get; set; }
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int precio { get; set; }

        public string? ProductoGuid { get; set; }
    }
}

