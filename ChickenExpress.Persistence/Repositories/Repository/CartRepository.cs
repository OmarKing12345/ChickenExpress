using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Persistence.ApplictionDbContext;
using ChickenExpress.Persistence.Repositories.Common;
using ChickenExpress.Persistence.Repositories.IRepository;

namespace ChickenExpress.Persistence.Repositories.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
