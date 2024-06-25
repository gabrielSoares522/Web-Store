using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public AddProductCommandHandler(IProductRepository productRepository) { 
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(0,
                request.Name,
                request.Description,
                request.Value,
                request.Quantity,
                request.IsAvailable,
                request.StoreId);

            _productRepository.Add(product);

            return Task.FromResult(Unit.Value);
        }
    }
}
