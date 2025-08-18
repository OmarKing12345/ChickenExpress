using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuCategories
{
    internal class GetMenuCategoriesHandler : ResponseHandler, IRequestHandler<GetMenuCategoriesQuery, Response<List<GetMenuCategoryResponse>>>
    {
        private readonly IMenuCategoriesService _menuCategoriesService;

        public GetMenuCategoriesHandler(IMenuCategoriesService menuCategoriesService)
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
