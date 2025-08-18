using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Persistence.Repositories.Common;

namespace ChickenExpress.Persistence.Repositories.IRepository
{
    public interface IMenuCategoryRepository: IRepository<MenuCategory>
    {
    }
}
