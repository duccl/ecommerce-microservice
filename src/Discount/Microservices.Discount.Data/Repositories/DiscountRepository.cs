using Dapper;
using Microservices.Discount.Domain.Entities;
using Microservices.Discount.Domain.Interfaces.Contexts;
using Microservices.Discount.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Microservices.Discount.Data.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        #region .: Properties :.

        public readonly IContext _context;

        #endregion

        #region .: Constructor :.

        public DiscountRepository(IContext context)
        {
            _context = context;
            SetupDb();
        }

        #endregion

        #region .: Methods :.

        private void SetupDb()
        {
            using var connection = _context.GetConnection();
            connection.Execute(
                "CREATE TABLE IF NOT EXISTS TB_VOUCHER" +
                "( ID SERIAL PRIMARY KEY, PRODUCT_NAME VARCHAR(24) NOT NULL UNIQUE, DESCRIPTION TEXT, AMOUNT DECIMAL NOT NULL CHECK (AMOUNT > 0)  )"
            );
        }

        #endregion

        #region .: IDiscountRepository Methods Implementation :.

        public async Task<bool> CreateVoucher(Voucher voucher)
        {
            using var connection = _context.GetConnection();

            var affectedRows = await connection.ExecuteAsync(
                "INSERT INTO TB_VOUCHER (PRODUCT_NAME, DESCRIPTION,AMOUNT) VALUES (@ProductName, @Description, @Amount)", 
                new { ProductName = voucher.ProductName, Description= voucher.Description, Amount= voucher.Amount }
            );

            if (affectedRows == 0)
                return false;
            return true;
        }

        public async Task<bool> DeleteVoucher(string productName)
        {
            using var connection = _context.GetConnection();

            var affectedRows = await connection.ExecuteAsync(
                "DELETE FROM TB_VOUCHER WHERE PRODUCT_NAME= @ProductName",
                new { ProductName = productName }
            );

            if (affectedRows == 0)
                return false;
            return true;
        }

        public async Task<Voucher> GetVoucher(string productName)
        {
            using var connection = _context.GetConnection();

            var voucher = await connection.QueryFirstOrDefaultAsync<Voucher>(
                "SELECT ID, DESCRIPTION, AMOUNT, PRODUCT_NAME AS ProductName FROM TB_VOUCHER WHERE PRODUCT_NAME= @ProductName", new { ProductName = productName}
            );

            if (voucher == null)
                return new Voucher { ProductName = "No discount", Amount = 0, Description = "No discount desc" };
            return voucher;
        }

        public async Task<bool> UpdateVoucher(Voucher voucher)
        {
            using var connection = _context.GetConnection();

            var affectedRows = await connection.ExecuteAsync(
                "UPDATE TB_VOUCHER SET PRODUCT_NAME=@ProductName, DESCRIPTION=@Description,AMOUNT=@Amount",
                new { ProductName = voucher.ProductName, Description = voucher.Description, Amount = voucher.Amount }
            );

            if (affectedRows == 0)
                return false;
            return true;
        }

        #endregion
    }
}
