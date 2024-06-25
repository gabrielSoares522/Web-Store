using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProductById;

namespace Web_store.Application.Queries.GetProductImageById
{
    internal class GetProductImageByIdQuery : IRequest<GetProductImageByIdViewModel>
    {
        public GetProductImageByIdQuery(int idProduct)
        {
            IdProduct = idProduct;
        }

        public int IdProduct { get; set; }
    }
}
