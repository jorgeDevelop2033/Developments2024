using System;
using MongoDB.Bson;

namespace WebApi.Modelo
{
    public class Cliente
    {
        public ObjectId Id { get; set; }
        public String? Name { get; set; }
        public String? Order { get; set; }
    }
}

