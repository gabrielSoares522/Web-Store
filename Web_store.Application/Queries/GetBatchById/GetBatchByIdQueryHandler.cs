using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetBatchById
{
    public class GetBatchByIdQueryHandler : IRequestHandler<GetBatchByIdQuery, GetBatchByIdViewModel>
    {
        private readonly IBatchRepository _batchRepository;
        public GetBatchByIdQueryHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }
        public Task<GetBatchByIdViewModel> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var batchs = _batchRepository.GetAll();

            var getBatchByIdViewModel = batchs
                .Select(s => new GetBatchByIdViewModel(s.Id,s.ProductId,s.Quantity))
                .FirstOrDefault(s => s.Id == request.IdBatch);

            return Task.FromResult(getBatchByIdViewModel);
        }
    }
}
