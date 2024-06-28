using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProductById;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetProductImageById
{
    public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQuery, GetProductImageByIdViewModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        public GetProductImageByIdQueryHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public Task<GetProductImageByIdViewModel> Handle(GetProductImageByIdQuery request, CancellationToken cancellationToken)
        {
            var productImages = _productImageRepository.GetAll();

            var getProductByIdViewModel = productImages
                .Select(s => new GetProductImageByIdViewModel(s.Id, s.BytesImage, s.ProductId, s.ImageName, s.CreatedAt, s.UpdateAt))
                .FirstOrDefault(s => s.Id == request.IdProductImage);

            return Task.FromResult(getProductByIdViewModel);
        }
    }
}
