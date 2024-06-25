using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.AddBatch
{
    public class AddBatchCommandHandler : IRequestHandler<AddBatchCommand, Unit>
    {
        private readonly IBatchRepository _batchRepository;
        public AddBatchCommandHandler(IBatchRepository batchRepository) {
            _batchRepository = batchRepository;
        }

        public Task<Unit> Handle(AddBatchCommand request, CancellationToken cancellationToken)
        {
            var batch = new Batch(0,request.ProductId,request.Quantity);

            _batchRepository.Add(batch);

            return Task.FromResult(Unit.Value);
        }
    }
}
