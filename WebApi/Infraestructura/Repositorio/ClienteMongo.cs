using System;
using WebApi.DbContext_V;
using WebApi.Modelo;

namespace WebApi.Data
{
    public class ClienteMongo
    {
        private readonly MyDbContext _myDbContext;

        public ClienteMongo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        public void AgregarCliente(Cliente cliente)
        {
            _myDbContext.Add(cliente);

            _myDbContext.SaveChanges();

        }
    }
}

