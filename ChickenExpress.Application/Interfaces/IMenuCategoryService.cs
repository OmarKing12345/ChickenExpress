using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategoryById;
using ChickenExpress.Domain.Entities;

namespace ChickenExpress.Application.Interfaces
{
    public interface IMenuCategoryService
    {
        Task<List<GetMenuCategoryResponse>> getAllMenuCategory();
        Task<GetMenuCategoryByIdResponse> GetMenuCategoryById(int Id);
        Task<bool> AddMenuCategory(MenuCategory menuCategory);
        Task<bool> DeleteMenuCategory(int Id);
        Task<GetMenuCategoryResponse> UpdateMenuCategory(MenuCategory menuCategory);
    }
}
