using ChickenExpress.Application.Features.Store.Command.AddStore;
using ChickenExpress.Application.Features.Store.Command.Delete_Store;
using ChickenExpress.Application.Features.Store.Command.UpdateStore;
using ChickenExpress.Application.Features.Store.Query.GetAllStores;
using ChickenExpress.Application.Features.Store.Query.GetStoreById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChickenExpress.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllStores")]
        public async Task<IActionResult> GetAllStores() {
            var result = await _mediator.Send(new GetAllStoresQuery());
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetStoreById")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var result = await _mediator.Send(new GetStoreByIdQuery(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddStore")]
        public async Task<IActionResult> AddStore([FromForm] AddStoreCommand addStoreCommand)
        {
            var result = await _mediator.Send(addStoreCommand);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpDelete("DeleteStore")]
        public async Task<IActionResult> DeleteStore([FromForm] DeleteStoreCommand deleteStoreCommand)
        {
            var result = await _mediator.Send(deleteStoreCommand);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpPut("UpdateStore")]
        public async Task<IActionResult> UpdateStore([FromForm] UpdateStoreCommand updateStoreCommand)
        {
            var result = await _mediator.Send(updateStoreCommand);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

    }
}
