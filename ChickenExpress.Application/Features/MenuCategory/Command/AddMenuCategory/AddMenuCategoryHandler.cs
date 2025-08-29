using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Command.AddMenuCategory
{
    public class AddMenuCategoryHandler : ResponseHandler, IRequestHandler<AddMenuCategoryCommand, Response<bool>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public AddMenuCategoryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public async Task<Response<bool>> Handle(AddMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var MenuCategory = new Domain.Entities.MenuCategory()
            {
               Name = request.Name,
               IsActive = request.IsActive,
               SortOrder=request.SortedOrder,
               
            };
            var result = await _menuCategoryService.AddMenuCategory(MenuCategory);
            if (result)
            {
                return Success(result,message:"The Menu Item Added Successfully");
            }
            return BadRequest<bool>();
        }
    }
}
