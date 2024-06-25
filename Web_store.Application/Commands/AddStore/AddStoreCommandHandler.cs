using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Commands.AddStore;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.AddStore
{
    internal class AddStoreCommandHandler : IRequestHandler<AddStoreCommand, Unit>
    {
        private readonly IStoreRepository _storeRepository;
        public AddStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Task<Unit> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store(0, request.Name, request.Description, request.Phone, request.Address, request.City,request.State,request.PostalCode,request.Country,request.AdminId);

            _storeRepository.Add(store);

            return Task.FromResult(Unit.Value);
        }
    }
}
