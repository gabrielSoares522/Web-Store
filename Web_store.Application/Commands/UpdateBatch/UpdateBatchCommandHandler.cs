using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.UpdateBatch
{
    public class UpdateBatchCommandHandler : IRequestHandler<UpdateBatchCommand, Unit>
    {
        private readonly IBatchRepository _batchRepository;
        public UpdateBatchCommandHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public Task<Unit> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {
            var batch = new Batch(request.Id, request.ProductId, request.Quantity);

            _batchRepository.Update(batch);

            return Task.FromResult(Unit.Value);
        }

    }
}
