using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategoryById
{
    internal class GetMenuCategoryByIdHandler : ResponseHandler, IRequestHandler<GetMenuCategoryByIdQuery, Response<GetMenuCategoryByIdResponse>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public GetMenuCategoryByIdHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public async Task<Response<GetMenuCategoryByIdResponse>> Handle(GetMenuCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result =await _menuCategoryService.GetMenuCategoryById(request.Id);
            if (result != null)
            {
                return Success(result,message:"The Menu Category Get Successfully");
            }
            return BadRequest<GetMenuCategoryByIdResponse>();
        }
    }
}
