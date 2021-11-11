using Microservices.Discount.Domain.Interfaces.Contexts;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Microservices.Discount.Data.Contexts
{
    public class Context : IContext
    {
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("POSTGRESQL_CONNECTION");
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
