using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository) { 
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Id,
                request.Name,
                request.Description,
                request.Value,
                request.Quantity,
                request.IsAvailable,
                request.StoreId);

            _productRepository.Update(product);

            return Task.FromResult(Unit.Value);
        }
    }
}
