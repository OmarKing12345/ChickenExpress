using ChickenExpress.Application.Features.MenuItems.Command.UpdateMenuItem;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Infrastructure.Services;
using MediatR;

public class UpdateMenuItemHandler : ResponseHandler, IRequestHandler<UpdateMenuItemCommand, Response<GetMenuItemsResponse>>
{
    private readonly IMenuItemService _menuItemService;
    private readonly IFileStorageService _fileStorageService;

    public UpdateMenuItemHandler(IMenuItemService menuItemService, IFileStorageService fileStorageService)
    {
        _menuItemService = menuItemService;
        _fileStorageService = fileStorageService;
    }

    public async Task<Response<GetMenuItemsResponse>> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var existing = await _menuItemService.GetMenuItemById(request.Id);
        if (existing == null)
            return NotFound<GetMenuItemsResponse>();

        string imageUrl = existing.ImageUrl;
        if (request.ImageUrl!= null) 
        {
            if (!string.IsNullOrEmpty(existing.ImageUrl))
                await _fileStorageService.DeleteFileAsync(existing.ImageUrl);

            imageUrl = await _fileStorageService.SaveFileAsync(request.ImageUrl, "Images");
        }

        var updated = new MenuItem()
        {
            Id = request.Id,
            CategoryId = request.CategoryId ?? existing.CategoryId,
            Name = request.Name ?? existing.Name,
            Description = request.Description ?? existing.Description,
            ImageUrl = imageUrl,
            IsActive = request.IsActive ?? existing.IsActive
        };

        var result = await _menuItemService.UpdateMenuItem(updated);
        if (result != null)
            return Success(result);

        return BadRequest<GetMenuItemsResponse>();
    }
}
