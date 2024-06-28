using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProducts;

namespace Web_store.Application.Queries.GetProductImages
{
    public class GetProductImagesQuery : IRequest<List<GetProductImagesViewModel>>
    {
        public GetProductImagesQuery(int idProduct)
        {
            IdProduct = idProduct;

        }

        public int IdProduct { get; set; }
    }
}
