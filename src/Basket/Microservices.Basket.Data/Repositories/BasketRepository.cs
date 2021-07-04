using Microservices.Basket.Domain.Entities;
using Microservices.Basket.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Microservices.Basket.Data.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        #region .: Properties

        private readonly ILogger<BasketRepository> _logger;
        private readonly IDistributedCache _cache;

        #endregion

        #region .: Constructor :.

        public BasketRepository(ILogger<BasketRepository> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region .: IBasketRepository Methods Implementation :.

        public async Task DeleteBasketAsync(string userName)
        {
            try
            {
                _logger.LogInformation($"Removing {userName} basket");
                await _cache.RemoveAsync(userName);
            }
            catch (Exception err)
            {
                _logger.LogError($"{err}");
                throw;
            }
            finally
            {
                _logger.LogInformation($"Removed {userName} basket");
            }
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName)
        {
            try
            {
                _logger.LogInformation($"Getting {userName} basket");
                var basketAsRawText = await _cache.GetStringAsync(userName);

                if (string.IsNullOrEmpty(basketAsRawText))
                {
                    _logger.LogWarning($"{userName} does not have a basket! We will create a new one");
                    return new ShoppingCart { UserName= userName };
                }

                return JsonConvert.DeserializeObject<ShoppingCart>(basketAsRawText);
            }
            catch (Exception err)
            {
                _logger.LogError($"{err}");
                throw;
            }
            finally
            {
                _logger.LogInformation($"{userName} basket retrieved");
            }
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            try
            {
                _logger.LogInformation($"Update/Insert {basket.UserName} basket");
                await _cache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
                return await GetBasketAsync(basket.UserName);
            }
            catch (Exception err)
            {
                _logger.LogError($"{err}");
                throw;
            }
            finally
            {
                _logger.LogInformation($"{basket.UserName} basket update/insert done!");
            }
        }

        #endregion
    }
}
