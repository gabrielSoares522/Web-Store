using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Web_store.Application.Commands.AddProductImage;
using Web_store.Application.Commands.RemoveProductImage;
using Web_store.Application.Commands.UpdateProductImage;
using Web_store.Application.Queries.GetProductImageById;
using Web_store.Application.Queries.GetProductImages;

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
            var query = new GetProductImagesQuery(idProduct);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{idProductImage}")]
        public async Task<IActionResult> GetProductImageById([FromRoute] int idProductImage)
        {
            var query = new GetProductImageByIdQuery(idProductImage);

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductImage(AddProductImageInputModel inputModel, IFormFile image)
        {
            byte[] imageBytes = new byte[0];
            if (image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    imageBytes = ms.ToArray();

                    const int length = 16;
                    Random random = new Random();
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    string imageName = new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    
                    inputModel.ImageName = imageName;
                    inputModel.BytesImage = imageBytes;
                }
            }
            
            var command = new AddProductImageCommand(inputModel.BytesImage, inputModel.ProductId, inputModel.ImageName);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage([FromBody] UpdateProductImageInputModel inputModel)//, IFormFile image)
        {
            //byte[] imageBytes = new byte[0];
            //if (image.Length > 0)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        image.CopyTo(ms);
            //        imageBytes = ms.ToArray();
            //    }
            //}

            var command = new UpdateProductImageCommand(inputModel.Id, inputModel.BytesImage, inputModel.ProductId, inputModel.ImageName);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{idProductImage}")]
        public async Task<IActionResult> RemoveProductImage([FromRoute] int idProductImage)
        {
            var command = new RemoveProductImageCommand(idProductImage);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
