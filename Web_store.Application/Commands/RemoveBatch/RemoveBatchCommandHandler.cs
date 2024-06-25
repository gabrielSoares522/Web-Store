using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.RemoveBatch
{
    public class RemoveBatchCommandHandler : IRequestHandler<RemoveBatchCommand, Unit>
    {
        private readonly IBatchRepository _batchRepository;
        public RemoveBatchCommandHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public Task<Unit> Handle(RemoveBatchCommand request, CancellationToken cancellationToken)
        {
            _batchRepository.removeById(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
