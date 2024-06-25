using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.RemoveBatch
{
    public class RemoveBatchCommand : IRequest<Unit>
    {
        public RemoveBatchCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
