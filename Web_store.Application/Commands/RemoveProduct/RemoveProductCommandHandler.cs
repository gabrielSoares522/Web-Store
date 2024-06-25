using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {

            _productRepository.removeById(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
