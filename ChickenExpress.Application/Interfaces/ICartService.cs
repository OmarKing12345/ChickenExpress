using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Entities;

namespace ChickenExpress.Application.Interfaces
{
    public interface ICartService
    {
         Task<List<CartItem>> GetAllCartsAsync(string userId);
    }
}