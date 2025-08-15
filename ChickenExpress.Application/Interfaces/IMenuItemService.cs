using ChickenExpress.Application.Features.MenuItems.Command.AddMenuItem;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItemById;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Infrastructure.Services
{
    public interface IMenuItemService
    {
        public Task<List<GetMenuItemsResponse>> GetAllMenuItems();
        public Task<GetMenuItemByIdResponse> GetMenuItemById(int MenuItemId);
        public Task<bool> AddMenuItem(MenuItem menuItem);

    }
}
