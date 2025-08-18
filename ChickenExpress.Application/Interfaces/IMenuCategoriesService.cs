using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuCategories;

namespace ChickenExpress.Application.Interfaces
{
    public interface IMenuCategoriesService
    {
        Task<List<GetMenuCategoryResponse>> getAllMenuCategory();
    }
}
