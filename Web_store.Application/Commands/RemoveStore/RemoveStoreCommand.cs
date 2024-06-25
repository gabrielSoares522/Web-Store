using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.RemoveStore
{
    public class RemoveStoreCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public RemoveStoreCommand(int id)
        {
            Id = id;
        }
    }
}
