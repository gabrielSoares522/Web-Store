using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_store.Application.Commands.AddBatch;
using Web_store.Application.Commands.RemoveBatch;
using Web_store.Application.Commands.UpdateBatch;
using Web_store.Application.Queries.GetBatchById;
using Web_store.Application.Queries.GetBatchs;

namespace Web_batch.API.Controllers
{
    [Route("api/[controller]")]
    public class BatchsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BatchsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBatchs(int idProduct)
        {
            var getBatchsQuery = new GetBatchsQuery(idProduct);

            var result = await _mediator.Send(getBatchsQuery);

            return Ok(result);
        }

        [HttpGet("{idBatch}")]
        public async Task<IActionResult> GetBatchById([FromRoute] int idBatch)
        {
            var getBatchByIdQuery = new GetBatchByIdQuery(idBatch);

            var result = await _mediator.Send(getBatchByIdQuery);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddBatch([FromBody] AddBatchInputModel batch)
        {
            var addBatchCommand = new AddBatchCommand(batch.ProductId, batch.Quantity);

            var result = await _mediator.Send(addBatchCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBatch([FromBody] UpdateBatchInputModel batch)
        {
            var updateBatchCommand = new UpdateBatchCommand(batch.Id, batch.ProductId, batch.Quantity);

            var result = await _mediator.Send(updateBatchCommand);

            return Ok(result);
        }

        [HttpDelete("{idBatch}")]
        public async Task<IActionResult> RemoveBatch([FromRoute] int idBatch)
        {
            var removeBatchCommand = new RemoveBatchCommand(idBatch);

            var result = await _mediator.Send(removeBatchCommand);

            return Ok(result);
        }
    }
}
