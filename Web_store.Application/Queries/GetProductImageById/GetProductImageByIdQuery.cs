using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProductById;

namespace Web_store.Application.Queries.GetProductImageById
{
    public class GetProductImageByIdQuery : IRequest<GetProductImageByIdViewModel>
    {
        public GetProductImageByIdQuery(int idProductImage)
        {
            IdProductImage = idProductImage;
        }

        public int IdProductImage { get; set; }
    }
}
