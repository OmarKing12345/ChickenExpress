using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategoryById;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.Interfaces;
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
    public class MenuCategoryService : IMenuCategoryService
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public MenuCategoryService(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<bool> AddMenuCategory(MenuCategory menuCategory)
        {
            var result = await _menuCategoryRepository.CreateAsync(menuCategory);
            if (result != null)
            {
                await _menuCategoryRepository.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMenuCategory(int Id)
        {
            var MenuCategory = await _menuCategoryRepository.GetOneAsync(x => x.Id == Id);
            if (MenuCategory != null) {
                var result = _menuCategoryRepository.Delete(MenuCategory);
                if (result) {
                    await _menuCategoryRepository.CommitAsync();
                    return true;
                
                }
                return false;
            }
            return false;
            
        }

        public async Task<List<GetMenuCategoryResponse>> getAllMenuCategory()
        {
            var result= await _menuCategoryRepository.GetAsync();

            return  result.Adapt<List<GetMenuCategoryResponse>>();
        }

        public async Task<GetMenuCategoryByIdResponse> GetMenuCategoryById(int Id)
        {
            var result = await _menuCategoryRepository.GetOneAsync(x=>x.Id == Id);
            return result.Adapt<GetMenuCategoryByIdResponse>();
        }

        public async Task<GetMenuCategoryResponse> UpdateMenuCategory(MenuCategory menuCategory)
        {
            var MenuItemInDB = await _menuCategoryRepository.GetOneAsync(x => x.Id == menuCategory.Id);
            if (MenuItemInDB == null)
                return null;

            MenuItemInDB.Id = menuCategory.Id != 0 ? menuCategory.Id : MenuItemInDB.Id;
            MenuItemInDB.Name = menuCategory.Name ?? MenuItemInDB.Name;
            MenuItemInDB.IsActive = menuCategory.IsActive; 
            MenuItemInDB.SortOrder = menuCategory.SortOrder != 0 ? menuCategory.SortOrder : MenuItemInDB.SortOrder;

            var result = _menuCategoryRepository.Update(MenuItemInDB);
            if (result != null)
            {
                await _menuCategoryRepository.CommitAsync();
                return result.Adapt<GetMenuCategoryResponse>();
            }

            return MenuItemInDB.Adapt<GetMenuCategoryResponse>();
        }
    }
}
