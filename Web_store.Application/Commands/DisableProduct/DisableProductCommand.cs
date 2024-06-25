using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.DisableProduct
{
    public class DisableProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DisableProductCommand(int id) {
            Id = id;
        }
    }
}
