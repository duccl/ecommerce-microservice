using Microservices.Discount.Domain.Entities;
using System.Threading.Tasks;

namespace Microservices.Discount.Domain.Interfaces.Repositories
{
    public interface IDiscountRepository
    {
        Task<Voucher> GetVoucher(string productName);
        Task<bool> CreateVoucher(Voucher voucher);
        Task<bool> UpdateVoucher(Voucher voucher);
        Task<bool> DeleteVoucher(string productName);
    }
}
