using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Command.DeleteMenuCaategory
{
    public class DeleteMenuCategoryHandler : ResponseHandler, IRequestHandler<DeleteMenuCategoryCommand, Response<bool>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public DeleteMenuCategoryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public async Task<Response<bool>> Handle(DeleteMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var result =await _menuCategoryService.DeleteMenuCategory(request.Id);
            if (result)
            {
                return Deleted<bool>();
            }
            return BadRequest<bool>();
        }
    }
}
