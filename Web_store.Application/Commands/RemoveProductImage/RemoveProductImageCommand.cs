using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.RemoveProductImage
{
    public class RemoveProductImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveProductImageCommand(int id)
        {
            Id = id;
        }
    }
}
