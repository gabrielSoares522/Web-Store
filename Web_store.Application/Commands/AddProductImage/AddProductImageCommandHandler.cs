using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.AddProductImage
{
    public class AddProductImageCommandHandler : IRequestHandler<AddProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _productImageRepository;
        public AddProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public Task<Unit> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new ProductImage(0,
                request.BytesImage,
                request.ProductId,
                request.ImageName);

            _productImageRepository.Add(productImage);

            return Task.FromResult(Unit.Value);
        }
    }
}
