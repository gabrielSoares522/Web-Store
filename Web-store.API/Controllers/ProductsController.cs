using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Web_store.Application.Commands.AddProduct;
using Web_store.Application.Commands.DisableProduct;
using Web_store.Application.Commands.RemoveProduct;
using Web_store.Application.Commands.UpdateProduct;
using Web_store.Application.Queries.GetProductById;
using Web_store.Application.Queries.GetProducts;
using Web_store.Domain.Entities;

namespace Web_store.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string search)
        {
            var getProductsQuery = new GetProductsQuery(search);

            var result = await _mediator.Send(getProductsQuery);

            return Ok(result);
        }

        [HttpGet("{idProduct}")]
        public async Task<IActionResult> GetProductById([FromRoute] int idProduct)
        {
            var getProductByIdQuery = new GetProductByIdQuery(idProduct);

            var result = await _mediator.Send(getProductByIdQuery);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]AddProductInputModel product)
        {
            var addProductCommand = new AddProductCommand(product.Name, product.Description, product.Value, product.Quantity, product.IsAvailable, product.StoreId);

            var result = await _mediator.Send(addProductCommand);

            return Ok(result);
        }

        [HttpPatch("Disable")]
        public async Task<IActionResult> DisableProduct([FromBody] DisableProductInputModel product)
        {
            var disableProductCommand = new DisableProductCommand(product.Id);

            var result = await _mediator.Send(disableProductCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductInputModel product)
        {
            var updateProductCommand = new UpdateProductCommand(product.Id, product.Name, product.Description, product.Value, product.Quantity, product.IsAvailable, product.StoreId);

            var result = await _mediator.Send(updateProductCommand);

            return Ok(result);
        }

        [HttpDelete("{idProduct}")]
        public async Task<IActionResult> RemoveProduct([FromRoute]int idProduct)
        {
            var removeProductCommand = new RemoveProductCommand(idProduct);

            var result = await _mediator.Send(removeProductCommand);

            return Ok(result);
        }
    }
}
