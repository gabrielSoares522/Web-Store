using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetProductById;

namespace Web_store.Application.Queries.GetStoreById
{
    public class GetStoreByIdQuery : IRequest<GetStoreByIdViewModel>
    {
        public GetStoreByIdQuery(int idStore)
        {
            IdStore = idStore;
        }

        public int IdStore { get; set; }
    }
}
