using ChickenExpress.Application.Features.MenuItems.Queries.GetCart;
using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChickenExpress.Api.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<CartItem>>>> GetAllCarts()
        {
            var userId = User.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User is not authenticated");

            var query = new GetCartQuery(userId);

            var result = await _mediator.Send(query);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return NotFound();
        }

    }
}
