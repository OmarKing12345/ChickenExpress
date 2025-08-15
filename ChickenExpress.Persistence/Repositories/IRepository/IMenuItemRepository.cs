using ChickenExpress.Domain.Entities;
using ChickenExpress.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Persistence.Repositories.IRepository
{
    public interface IMenuItemRepository:IRepository<MenuItem>
    {
    }
}
