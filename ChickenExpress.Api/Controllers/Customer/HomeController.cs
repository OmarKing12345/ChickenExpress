using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChickenExpress.Api.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
         private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("menu")]
        public async Task<ActionResult> GetMenuItems()
        {
            var result = await _mediator.Send(new GetMenuItemsQuery());
            return Ok(result);
        }

        [HttpGet("menuCategory")]
        public async Task<ActionResult> GetMenuCategories()
        {
            var result = await _mediator.Send(new GetMenuCategoriesQuery());

            return Ok(result);
        }

    }
}
