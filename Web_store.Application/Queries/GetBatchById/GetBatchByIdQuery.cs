using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetBatchById;

namespace Web_store.Application.Queries.GetBatchById
{
    public class GetBatchByIdQuery : IRequest<GetBatchByIdViewModel>
    {
        public GetBatchByIdQuery(int idBatch)
        {
            IdBatch = idBatch;
        }

        public int IdBatch { get; set; }
    }
}
