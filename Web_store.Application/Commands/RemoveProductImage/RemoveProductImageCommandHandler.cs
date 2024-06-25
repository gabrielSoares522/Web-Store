using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _productImageRepository;
        public RemoveProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public Task<Unit> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {

            _productImageRepository.removeById(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
