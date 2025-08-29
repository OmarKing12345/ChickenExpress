using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;

namespace ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories
{
    internal class GetMenuCategoriesHandler : ResponseHandler, IRequestHandler<GetMenuCategoriesQuery, Response<List<GetMenuCategoryResponse>>>
    {
        private readonly IMenuCategoryService _menuCategoriesService;

        public GetMenuCategoriesHandler(IMenuCategoryService menuCategoriesService)
        {
            _menuCategoriesService = menuCategoriesService;
        }

        public async Task<Response<List<GetMenuCategoryResponse>>> Handle(GetMenuCategoriesQuery request, CancellationToken cancellationToken)
        {

            var result = await _menuCategoriesService.getAllMenuCategory();

            if (result == null)
            {
                return NotFound<List<GetMenuCategoryResponse>>("No Category Found");
            }
            return Success(result,message:"Data Get success");
        }

    }
}
