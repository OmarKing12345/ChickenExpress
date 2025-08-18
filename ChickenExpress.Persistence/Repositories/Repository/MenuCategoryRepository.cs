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
    public class MenuCategoryRepository : Repository<MenuCategory>,IMenuCategoryRepository
    {
        public MenuCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
}
