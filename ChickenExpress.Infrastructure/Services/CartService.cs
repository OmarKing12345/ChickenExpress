using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.Interfaces;
using StackExchange.Redis;
using System.Text.Json;
using ChickenExpress.Persistence.ApplictionDbContext;
using ChickenExpress.Persistence.Repositories.IRepository;
using ChickenExpress.Domain.Entities;

namespace ChickenExpress.Infrastructure.Services
{
    public class CartService: ICartService
    {
        private readonly IDatabase _redisDb;
        private readonly string _prefix = "cart:";
        private readonly ICartRepository _cartRepository;


        public CartService(IConnectionMultiplexer redis, ICartRepository cartRepository)
        {
            _redisDb = redis.GetDatabase();
            _cartRepository = cartRepository;
        }

        
        public async Task<List<CartItem>> GetAllCartsAsync(string userId)
        {

            var key = _prefix + userId;
            var cartJson = await _redisDb.StringGetAsync(key);
            return cartJson.IsNullOrEmpty ? new List<CartItem>() :
                JsonSerializer.Deserialize<List<CartItem>>(cartJson)!;
        }

      
    }
}
