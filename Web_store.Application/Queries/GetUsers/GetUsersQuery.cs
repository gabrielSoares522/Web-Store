using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProducts;

namespace Web_store.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<GetUsersViewModel>>
    {
        public GetUsersQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
