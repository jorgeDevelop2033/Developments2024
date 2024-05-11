using System;
using MongoDB.Driver;
using MongoDB.Entities;

namespace WebApi.db
{
    public class conexionDB
    {
        public conexionDB()
        {

        }

        public async void createConexionDBMongo()
        {
            const string dbName = "db_sample2024";

            const string stringConexion = $"mongodb+srv://jorge:09mayo84@cluster1.6s6mtsc.mongodb.net/{dbName}?retryWrites=true&w=majority";

            await DB.InitAsync("DatabaseName",
                    MongoClientSettings.FromConnectionString(stringConexion));

        }

    }
}

