using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetStores
{
    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, List<GetStoresViewModel>>
    {
        private readonly IStoreRepository _storeRepository;
        public GetStoresQueryHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public Task<List<GetStoresViewModel>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = _storeRepository.GetAll();
            if (request.Search == null)
            {
                var getStoresViewModelList = stores
                    .Select(s => new GetStoresViewModel(s.Id, s.Name, s.Description, s.Phone, s.Address, s.City, s.State, s.PostalCode,s.Country,s.AdminId))
                    .ToList();

                return Task.FromResult(getStoresViewModelList);
            }
            else
            {
                var getStoresViewModelList = stores
                    .Select(s => new GetStoresViewModel(s.Id, s.Name, s.Description, s.Phone, s.Address, s.City, s.State, s.PostalCode, s.Country, s.AdminId))
                    .Where(s => s.Name.ToUpper().Contains(request.Search.ToUpper()))
                    .ToList();

                return Task.FromResult(getStoresViewModelList);

            }
        }
    }
}
