using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<BasketCheckoutModel>> GetOrdersByUserName(string userName);
    }
}
