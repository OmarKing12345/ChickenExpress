using ChickenExpress.Application.Features.MenuItems.Command.AddMenuItem;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItemById;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChickenExpress.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMenueItem")]
        public async Task<ActionResult<List<GetMenuItemsResponse>>> GetMenuItems()
        {
            var result = await _mediator.Send(new GetMenuItemsQuery());
            return Ok(result);
        }
        [HttpGet("GetMenueItemById")]
        public async Task<ActionResult<GetMenuItemByIdResponse>> GetMenuItemById(int id)
        {
            var result = await _mediator.Send(new GetMenuItemByIdQuery(id));
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
            
        }
        [HttpPost("AddMenuItem")]
        public async Task<IActionResult> AddMenuItem([FromBody] AddMenuItemCommand addMenuItemCommand)
        {
            var result = await _mediator.Send(addMenuItemCommand);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }




    }
}
