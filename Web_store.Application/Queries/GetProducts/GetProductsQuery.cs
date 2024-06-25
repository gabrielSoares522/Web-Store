using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Queries.GetProducts
{
    public class GetProductsQuery: IRequest<List<GetProductsViewModel>>
    {
        public GetProductsQuery(string search) {
            Search = search;

        }

        public string Search {  get; set; }
    }
}
