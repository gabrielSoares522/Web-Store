using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_store.Application.Commands.AddStore;
using Web_store.Application.Commands.RemoveStore;
using Web_store.Application.Commands.UpdateStore;
using Web_store.Application.Queries.GetStoreById;
using Web_store.Application.Queries.GetStores;

namespace Web_store.API.Controllers
{
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores(string search)
        {
            var getStoresQuery = new GetStoresQuery(search);

            var result = await _mediator.Send(getStoresQuery);

            return Ok(result);
        }

        [HttpGet("{idStore}")]
        public async Task<IActionResult> GetStoreById([FromRoute] int idStore)
        {
            var getStoreByIdQuery = new GetStoreByIdQuery(idStore);

            var result = await _mediator.Send(getStoreByIdQuery);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] AddStoreInputModel store)
        {
            var addStoreCommand = new AddStoreCommand(store.Name, store.Description, store.Phone, store.Address, store.City,store.State,store.PostalCode,store.Country,store.AdminId);

            var result = await _mediator.Send(addStoreCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateStoreInputModel store)
        {
            var updateStoreCommand = new UpdateStoreCommand(store.Id, store.Name, store.Description, store.Phone, store.Address, store.City, store.State, store.PostalCode, store.Country, store.AdminId);

            var result = await _mediator.Send(updateStoreCommand);

            return Ok(result);
        }

        [HttpDelete("{idStore}")]
        public async Task<IActionResult> RemoveStore([FromRoute] int idStore)
        {
            var removeStoreCommand = new RemoveStoreCommand(idStore);

            var result = await _mediator.Send(removeStoreCommand);

            return Ok(result);
        }
    }
}
