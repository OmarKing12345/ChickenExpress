using ChickenExpress.Application.Features.MenuCategory.Command.AddMenuCategory;
using ChickenExpress.Application.Features.MenuCategory.Command.DeleteMenuCaategory;
using ChickenExpress.Application.Features.MenuCategory.Command.UpdateMenuCategory;
using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategoryById;
using ChickenExpress.Application.Features.MenuItems.Command.UpdateMenuItem;
using ChickenExpress.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ChickenExpress.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMenuCategory")]
        public async Task<IActionResult> GetAllMenuCategory()
        {
            var result = await _mediator.Send(new GetMenuCategoriesQuery());
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetMenuCategoryById")]
        public async Task<IActionResult> GetMenuCategoryById(int id)
        {
            var result = await _mediator.Send(new GetMenuCategoryByIdQuery(id));
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("AddMenuCategory")]
        public async Task<IActionResult> AddMenuCategory(AddMenuCategoryCommand addMenuCategoryCommand)
        {
            var result = await _mediator.Send(addMenuCategoryCommand);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("DeleteMenuCategory")]
        public async Task<IActionResult> DeleteMenuCategory(int Id)
        {
            var result = await _mediator.Send(new DeleteMenuCategoryCommand(Id));
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("UpdateMenuCategory")]
        public async Task<IActionResult> UpdateMenuCategory(UpdateMenuCategoryCommand updateMenuCategoryCommand)
        {
            var result = await _mediator.Send(updateMenuCategoryCommand);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }


    }
}
