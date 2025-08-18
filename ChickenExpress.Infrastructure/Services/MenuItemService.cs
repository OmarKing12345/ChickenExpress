using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItemById;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Persistence.Repositories.IRepository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Infrastructure.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuRepository;

        public MenuItemService(IMenuItemRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<bool> AddMenuItem(MenuItem menuItem)
        {
            var result = await _menuRepository.CreateAsync(menuItem);
            if(result != null)
            {
                await _menuRepository.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMenuItem(int MenuItemId)
        {
            var MenuItem = await _menuRepository.GetOneAsync(expression: x => x.Id == MenuItemId);
            if(MenuItem != null)
            {
                var result = _menuRepository.Delete(MenuItem);
                if(result)
                {
                    await _menuRepository.CommitAsync();
                    return true;
                }
                return false;
            }
            return false;
            
        }

        public async Task<List<GetMenuItemsResponse>> GetAllMenuItems()
        {
            var items = await _menuRepository.GetAsync();
            return items.Adapt<List<GetMenuItemsResponse>>();
        }

        public async Task<GetMenuItemByIdResponse> GetMenuItemById(int MenuItemId)
        {
            var item = await _menuRepository.GetOneAsync(expression: i => i.Id == MenuItemId);
            return item.Adapt<GetMenuItemByIdResponse>();
        }

        public async Task<GetMenuItemsResponse> UpdateMenuItem(MenuItem menuItem)
        {
            var MenuItemInDB = await _menuRepository.GetOneAsync(x => x.Id == menuItem.Id);
            if (MenuItemInDB == null)
                return null;

            MenuItemInDB.CategoryId = menuItem.CategoryId != 0 ? menuItem.CategoryId : MenuItemInDB.CategoryId;
            MenuItemInDB.Name = menuItem.Name ?? MenuItemInDB.Name;
            MenuItemInDB.Description = menuItem.Description ?? MenuItemInDB.Description;
            MenuItemInDB.ImageUrl = menuItem.ImageUrl ?? MenuItemInDB.ImageUrl;
            MenuItemInDB.IsActive = menuItem.IsActive ?? MenuItemInDB.IsActive;

            var result = _menuRepository.Update(MenuItemInDB);
            if (result != null)
            {
                await _menuRepository.CommitAsync();
                return result.Adapt<GetMenuItemsResponse>();
            }

            return MenuItemInDB.Adapt<GetMenuItemsResponse>();
        }



    }
}
