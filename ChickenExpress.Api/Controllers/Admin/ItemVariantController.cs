using ChickenExpress.Application.Features.ItemVariant.Command.AddItemVariant;
using ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant;
using ChickenExpress.Application.Features.ItemVariant.Command.GetItemVariantById;
using ChickenExpress.Application.Features.ItemVariantt.Command.DeleteItemVariant;
using ChickenExpress.Application.Features.ItemVariantt.Command.UpdateItemVariant;
using ChickenExpress.Domain.Entities;
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
            if (result.Succeeded)
            {
                return Ok(result);
                
            }
            return NotFound();

        }


        [HttpGet("GetItemVariantById")]
        public async Task<IActionResult> GetItemVariantById( int Id)
        {
            var result = await _mediator.Send(new GetItemVariantByIdQuery(Id));
            if (result.Succeeded)
            {
                return Ok(result);
               
            }

            return NotFound();
        }

        [HttpPost("AddItemVariant")]
        public async Task<IActionResult> AddItemVariant(AddItemVariantCommand addItemVariantCommand)
        {
            var result = await _mediator.Send(addItemVariantCommand);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("DeleteItemVariant")]
        public async Task<IActionResult> DeleteItemVariant(int ItemVariantId)
        {
            var result = await _mediator.Send(new DeleteItemVariantCommand(ItemVariantId));
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateItemVariant")]
        public async Task<IActionResult> UpdateItemVariant(UpdateItemVariantCommand updateItemVariantCommand)
        {
            var result = await _mediator.Send(updateItemVariantCommand);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
