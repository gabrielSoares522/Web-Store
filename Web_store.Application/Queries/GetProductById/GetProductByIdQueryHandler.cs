using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProducts;
using Web_store.Domain.Repository;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdViewModel>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<GetProductByIdViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll();

            var getProductByIdViewModel = products
                .Select(s => new GetProductByIdViewModel(s.Id, s.Name, s.Description, s.Value, s.Quantity, s.IsAvailable, s.CreatedAt, s.UpdateAt, s.StoreId))
                .FirstOrDefault(s => s.Id == request.IdProduct);
            
            return Task.FromResult(getProductByIdViewModel);
        }
    }
}
