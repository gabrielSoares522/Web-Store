using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.RemoveStore
{
    public class RemoveStoreCommandHandler : IRequestHandler<RemoveStoreCommand, Unit>
    {
        private readonly IStoreRepository _storeRepository;
        public RemoveStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Task<Unit> Handle(RemoveStoreCommand request, CancellationToken cancellationToken)
        {
            _storeRepository.removeById(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
