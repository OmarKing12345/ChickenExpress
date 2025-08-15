using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Command.AddMenuItem
{
    public class AddMenuItemHandler : ResponseHandler, IRequestHandler<AddMenuItemCommand, Response<bool>>
    {
        private readonly IMenuItemService _menuItemService;

        public AddMenuItemHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public async Task<Response<bool>> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {
            var item = new MenuItem
            {
                CategoryId = request.CategoryId,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                IsActive = request.IsActive,
                Name = request.Name,
            };

            var result = await _menuItemService.AddMenuItem(item);
            if (result)
            {
                return Success(true);
            }

            return BadRequest<bool>(); 
        }
    }
}
