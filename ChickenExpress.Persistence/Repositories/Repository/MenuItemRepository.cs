using ChickenExpress.Domain.Entities;
using ChickenExpress.Persistence.ApplictionDbContext;
using ChickenExpress.Persistence.Repositories.Common;
using ChickenExpress.Persistence.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Persistence.Repositories.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
