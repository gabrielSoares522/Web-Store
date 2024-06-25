using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
    {
        private readonly IStoreRepository _storeRepository;
        public UpdateStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store(request.Id, request.Name, request.Description, request.Phone, request.Address, request.City, request.State, request.PostalCode, request.Country, request.AdminId);

            _storeRepository.Update(store);

            return Task.FromResult(Unit.Value);
        }
    }
}
