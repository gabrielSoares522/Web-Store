using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProducts;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQuery, List<GetProductImagesViewModel>>
    {
        private readonly IProductImageRepository _productImageRepository;
        public GetProductImagesQueryHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public Task<List<GetProductImagesViewModel>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
        {
            var productImages = _productImageRepository.GetAll();
            if (request.IdProduct == null)
            {
                var getProductImagesViewModelList = productImages
                    .Select(s => new GetProductImagesViewModel(s.Id, s.BytesImage, s.ProductId, s.ImageName, s.CreatedAt, s.UpdateAt))
                    .ToList();

                return Task.FromResult(getProductImagesViewModelList);
            }
            else
            {
                var getProductImagesViewModelList = productImages
                    .Select(s => new GetProductImagesViewModel(s.Id, s.BytesImage, s.ProductId, s.ImageName, s.CreatedAt, s.UpdateAt))
                    .Where(s => s.ProductId == request.IdProduct)
                    .ToList();

                return Task.FromResult(getProductImagesViewModelList);

            }
        }
    }
}
