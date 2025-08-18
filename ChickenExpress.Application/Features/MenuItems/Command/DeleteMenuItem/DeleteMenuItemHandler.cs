using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Command.DeleteMenuItem
{
    public class DeleteMenuItemHandler : ResponseHandler, IRequestHandler<DeleteMenuItemCommand, Response<bool>>
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IFileStorageService _fileStorageService;

        public DeleteMenuItemHandler(IMenuItemService menuItemService, IFileStorageService fileStorageService)
        {
            _menuItemService = menuItemService;
            _fileStorageService = fileStorageService;
        }

        public async Task<Response<bool>> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = await _menuItemService.GetMenuItemById(request.MenuItemId);
            if (menuItem == null)
                return NotFound<bool>();

            if (!string.IsNullOrEmpty(menuItem.ImageUrl))
            {
                await _fileStorageService.DeleteFileAsync(menuItem.ImageUrl);
            }

            var result = await _menuItemService.DeleteMenuItem(request.MenuItemId);

            if (result)
                return Deleted<bool>();

            return NotFound<bool>();
        }
    }
}

