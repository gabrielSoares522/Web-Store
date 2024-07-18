using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.AddProductImage
{
    public class AddProductImageCommandHandler : IRequestHandler<AddProductImageCommand, ProductImage>
    {
        private readonly IProductImageRepository _productImageRepository;
        public AddProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public Task<ProductImage> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new ProductImage(0,
                request.BytesImage,
                request.ProductId,
                request.ImageName);

            var newProductImage = _productImageRepository.Add(productImage);

            return Task.FromResult(newProductImage);
        }
    }
}
