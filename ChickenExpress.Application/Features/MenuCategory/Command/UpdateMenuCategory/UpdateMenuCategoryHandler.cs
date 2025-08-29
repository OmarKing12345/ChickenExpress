using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Infrastructure.Services;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Command.UpdateMenuCategory
{
    public class UpdateMenuCategoryHandler : ResponseHandler, IRequestHandler<UpdateMenuCategoryCommand, Response<GetMenuCategoryResponse>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public UpdateMenuCategoryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public async Task<Response<GetMenuCategoryResponse>> Handle(UpdateMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _menuCategoryService.GetMenuCategoryById(request.Id);
            if (existing == null)
                return NotFound<GetMenuCategoryResponse>();

            var updated = new Domain.Entities.MenuCategory()
            {
                Id= request.Id,
                IsActive=request.IsActive??existing.IsActive,
                Name=request.Name??existing.Name,
                SortOrder=request.SortedOrder??existing.SortOrder
            };

            var result = await _menuCategoryService.UpdateMenuCategory(updated);
            if (result != null)
                return Success(result);

            return BadRequest<GetMenuCategoryResponse>();
        }

    }
}
