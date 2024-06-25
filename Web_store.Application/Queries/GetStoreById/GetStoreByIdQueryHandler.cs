using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetStoreById
{
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, GetStoreByIdViewModel>
    {
        private readonly IStoreRepository _storeRepository;
        public GetStoreByIdQueryHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public Task<GetStoreByIdViewModel> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var stores = _storeRepository.GetAll();

            var getStoreByIdViewModel = stores
                .Select(s => new GetStoreByIdViewModel(s.Id, s.Name, s.Description, s.Phone, s.Address, s.City, s.State, s.PostalCode, s.Country, s.AdminId))
                .FirstOrDefault(s => s.Id == request.IdStore);

            return Task.FromResult(getStoreByIdViewModel);
        }
    }
}
