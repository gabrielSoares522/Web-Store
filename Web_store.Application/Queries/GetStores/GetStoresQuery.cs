using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProducts;

namespace Web_store.Application.Queries.GetStores
{
    public class GetStoresQuery : IRequest<List<GetStoresViewModel>>
    {
        public GetStoresQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
