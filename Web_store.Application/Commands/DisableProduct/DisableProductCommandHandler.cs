using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.DisableProduct
{
    public class DisableProductCommandHandler : IRequestHandler<DisableProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DisableProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(DisableProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _productRepository.GetById(request.Id);
            
            product.IsAvailable = false;

            _productRepository.Update(product);

            return Task.FromResult(Unit.Value);
        }
    }
}
