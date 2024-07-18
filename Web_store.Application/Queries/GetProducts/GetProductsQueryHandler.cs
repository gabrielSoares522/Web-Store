using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsViewModel>>
    {
        private readonly IProductRepository _productRepository; 
        private readonly IProductImageRepository _productImageRepository;

        public GetProductsQueryHandler(IProductRepository productRepository,IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }
        public Task<List<GetProductsViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll();
            var productImages = _productImageRepository.GetAll();
            if (request.Search == null)
            {
                //(from p in people
                // join pts in pets on p equals pts.Owner
                // select p).Distinct();
                var getProductsViewModelList = (from p in products
                                               join pi in productImages on p equals pi.Product
                                               select new GetProductsViewModel(p.Id, p.Name, p.Description, p.Value, p.Quantity, p.IsAvailable, p.CreatedAt, p.UpdateAt, pi.BytesImage)
                                               ).DistinctBy(p => p.Id).ToList();
                /*var getProductsViewModelList = products
                    .Select(s => new GetProductsViewModel(s.Id, s.Name, s.Description, s.Value, s.Quantity, s.IsAvailable, s.CreatedAt, s.UpdateAt,null))// s.ProductImages.Count))
                    .ToList();*/

                return Task.FromResult(getProductsViewModelList);
            }else
            {
                var getProductsViewModelList = (from p in products
                                                join pi in productImages on p equals pi.Product
                                                select new GetProductsViewModel(p.Id, p.Name, p.Description, p.Value, p.Quantity, p.IsAvailable, p.CreatedAt, p.UpdateAt, pi.BytesImage)
                                               )
                    .Where(s => s.Name.ToUpper().Contains(request.Search.ToUpper()))
                    .ToList();
                /*var getProductsViewModelList = products
                    .Select(s => new GetProductsViewModel(s.Id, s.Name, s.Description, s.Value, s.Quantity, s.IsAvailable, s.CreatedAt, s.UpdateAt,null))// s.ProductImages.Count))
                    .Where(s => s.Name.ToUpper().Contains(request.Search.ToUpper()))
                    .ToList();*/

                return Task.FromResult(getProductsViewModelList);

            }
        }
    }
}
