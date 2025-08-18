using ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant;
using ChickenExpress.Application.Features.ItemVariant.Command.GetItemVariantById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChickenExpress.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemVariantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemVariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllItemVariant")]
        public async Task<IActionResult> GetAllItemVariant()
        {
            var result = await _mediator.Send(new GetAllItemVariantQuery());
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("GetItemVariantById")]
        public async Task<IActionResult> GetItemVariantById( int Id)
        {
            var result = await _mediator.Send(new GetItemVariantByIdQuery(Id));
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}
