using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Application.Commands.AddBatch
{
    public class AddBatchCommand: IRequest<Unit>
    {
        public AddBatchCommand(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
