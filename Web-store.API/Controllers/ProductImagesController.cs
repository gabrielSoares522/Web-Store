using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_store.Application.Commands.AddProductImage;
using Web_store.Application.Commands.RemoveProductImage;
using Web_store.Application.Commands.UpdateProductImage;
//using Web_store.Application.Queries.GetProductImageById;
//using Web_store.Application.Queries.GetProductImages;

namespace Web_store.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImage(int idProduct)
        {
            //var getProductImagesQuery = new GetProductImagesQuery(idProduct);

            //var result = await _mediator.Send(getProductImagesQuery);

            //return Ok(result);
            return Ok();
        }

        [HttpGet("{idProductImage}")]
        public async Task<IActionResult> GetProductImageById([FromRoute] int idProductImage)
        {
            //var getProductImageByIdQuery = new GetProductImageByIdQuery(idProductImage);

            //var result = await _mediator.Send(getProductImageByIdQuery);

            //return Ok(result);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddProductImage([FromBody] AddProductImageInputModel inputModel, IFormFile image)
        {
            byte[] imageBytes = new byte[0];
            if (image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
            }
            

            var addProductImageCommand = new AddProductImageCommand(imageBytes, inputModel.ProductId, image.Name);

            var result = await _mediator.Send(addProductImageCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage([FromBody] UpdateProductImageInputModel productImage)
        {
            //var updateProductImageCommand = new UpdateProductImageCommand(productImage.Id, productImage.Name, productImage.Description, productImage.Value, productImage.Quantity, productImage.IsAvailable, productImage.StoreId);

            //var result = await _mediator.Send(updateProductImageCommand);

            //return Ok(result);
            return Ok();
        }

        [HttpDelete("{idProductImage}")]
        public async Task<IActionResult> RemoveProductImage([FromRoute] int idProductImage)
        {
            //var removeProductImageCommand = new RemoveProductImageCommand(idProductImage);

            //var result = await _mediator.Send(removeProductImageCommand);

            //return Ok(result);
            return Ok();
        }
    }
}
