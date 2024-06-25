using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.UpdateProductImage
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _productImageRepository;
        public UpdateProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public Task<Unit> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductImage(request.Id,
                request.BytesImage,
                request.ProductId,
                request.ImageName);



        _productImageRepository.Update(product);

            return Task.FromResult(Unit.Value);
        }
    }
}
