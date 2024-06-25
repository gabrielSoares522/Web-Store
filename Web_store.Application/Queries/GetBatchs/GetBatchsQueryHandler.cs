using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetBatchs
{
    public class GetBatchsQueryHandler : IRequestHandler<GetBatchsQuery, List<GetBatchsViewModel>>
    {
        private readonly IBatchRepository _batchRepository;
        public GetBatchsQueryHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }
        public Task<List<GetBatchsViewModel>> Handle(GetBatchsQuery request, CancellationToken cancellationToken)
        {
            var batchs = _batchRepository.GetAll();
            if (request.IdProduct == 0)
            {
                var getBatchsViewModelList = batchs
                    .Select(s => new GetBatchsViewModel(s.Id, s.ProductId, s.Quantity))
                    .ToList();

                return Task.FromResult(getBatchsViewModelList);
            }
            else
            {
                var getBatchsViewModelList = batchs
                    .Select(s => new GetBatchsViewModel(s.Id, s.ProductId, s.Quantity))
                    .Where(s => s.ProductId == request.IdProduct)
                    .ToList();

                return Task.FromResult(getBatchsViewModelList);

            }
        }
    }
}
