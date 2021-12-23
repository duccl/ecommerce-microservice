using Microservices.Ordering.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Microservices.Ordering.Infraestructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(ContextBase context, ILogger<OrderContextSeed> logger)
        {
            try
            {
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(GetPreconfiguredOrders());
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seed made! {context}", context);
                }
            }
            catch (Exception err)
            {
                logger.LogError(err, "Seed not made for {context}:", context);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order> 
            { 
                new Order()
                {
                    UserName = "duccl",
                    TotalPrice = 150,
                    Address = new Address
                    {
                        Country = "BRA",
                        FirstName = "SUPER",
                        LastName = "GUY",
                        AddressLine = "EMAIL",
                        EmailAddress = "super-guy@email.com",
                        State = "ACR",
                        ZipCode = "12356013-23"
                    },
                    Payment = new Payment
                    {
                        CardName = "master",
                        CardNumber = "2123414141421313",
                        CVV = "000",
                        Expiration = "99/99",
                        PaymentMethod = 2
                    }
                }
            };
        }
    }
}
