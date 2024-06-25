using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<List<GetProductsViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll();
            if (request.Search == null)
            {
                var getProductsViewModelList = products
                    .Select(s => new GetProductsViewModel(s.Id, s.Name, s.Description, s.Value, s.Quantity, s.IsAvailable, s.CreatedAt, s.UpdateAt))
                    .ToList();

                return Task.FromResult(getProductsViewModelList);
            }else
            {
                var getProductsViewModelList = products
                    .Select(s => new GetProductsViewModel(s.Id, s.Name, s.Description, s.Value, s.Quantity, s.IsAvailable, s.CreatedAt, s.UpdateAt))
                    .Where(s => s.Name.ToUpper().Contains(request.Search.ToUpper()))
                    .ToList();

                return Task.FromResult(getProductsViewModelList);

            }
        }
    }
}
