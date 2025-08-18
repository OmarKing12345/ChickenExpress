using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuCategories;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Persistence.Repositories.IRepository;
using Mapster;

namespace ChickenExpress.Infrastructure.Services
{
    public class MenuCategoryService : IMenuCategoriesService
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public MenuCategoryService(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task<List<GetMenuCategoryResponse>> getAllMenuCategory()
        {
            var result= await _menuCategoryRepository.GetAsync();

            return  result.Adapt<List<GetMenuCategoryResponse>>();
        }
    }
}
