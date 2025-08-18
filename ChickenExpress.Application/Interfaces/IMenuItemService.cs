using ChickenExpress.Application.Features.MenuItems.Command.AddMenuItem;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItemById;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.ResponsesApi;
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
        public Task<bool> DeleteMenuItem(int MenuItemId);
        public Task<GetMenuItemsResponse> UpdateMenuItem(MenuItem menuItem);

    }
}
