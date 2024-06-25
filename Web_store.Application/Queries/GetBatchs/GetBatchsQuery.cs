using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProducts;

namespace Web_store.Application.Queries.GetBatchs
{
    public class GetBatchsQuery : IRequest<List<GetBatchsViewModel>>
    {
        public GetBatchsQuery(int idProduct)
        {
            IdProduct = idProduct;

        }

        public int IdProduct { get; set; }
    }
}
