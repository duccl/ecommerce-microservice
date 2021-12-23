using Microservices.Ordering.Application.Contracts.Persistence;
using Microservices.Ordering.Domain.Entities;
using Microservices.Ordering.Infraestructure.Persistence;
using Microservices.Ordering.Infraestructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Ordering.Infraestructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ContextBase context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orders = await _context.Orders
                .Where(order => order.UserName.Equals(userName))
                .Include(order => order.Address)
                .Include(order => order.Payment)
                .ToListAsync();

            return orders;
        }
    }
}
