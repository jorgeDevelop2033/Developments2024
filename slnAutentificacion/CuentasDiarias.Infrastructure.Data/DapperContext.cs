using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CuentasDiarias.Infrastructure.Data

{
    public class DapperContext 
    {

        public readonly IConfiguration _configuration;
        public readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("CadenaConexion");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString); 
    }
}