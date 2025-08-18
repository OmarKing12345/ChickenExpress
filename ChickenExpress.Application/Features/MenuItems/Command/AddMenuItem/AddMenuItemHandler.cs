using ChickenExpress.Application.Interfaces;
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
        private readonly IFileStorageService _fileStorageService;

        public AddMenuItemHandler(IMenuItemService menuItemService, IFileStorageService fileStorageService)
        {
            _menuItemService = menuItemService;
            _fileStorageService = fileStorageService;
        }

        public async Task<Response<bool>> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {
            string? imagePath = null;

            if (request.ImageUrl != null)
            {
                imagePath = await _fileStorageService.SaveFileAsync(request.ImageUrl, "images");
            }

            var menuItem = new MenuItem
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Description = request.Description,
                ImageUrl = imagePath,
                IsActive = request.IsActive
            };

            await _menuItemService.AddMenuItem(menuItem);

            return new Response<bool>(true, "Menu item created successfully");
        }
    }
}
