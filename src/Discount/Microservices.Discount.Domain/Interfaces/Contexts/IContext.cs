using Npgsql;

namespace Microservices.Discount.Domain.Interfaces.Contexts
{
    public interface IContext
    {
        NpgsqlConnection GetConnection();
    }
}
