using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.UpdateBatch
{
    public class UpdateBatchCommand : IRequest<Unit>
    {
        public UpdateBatchCommand(int id, int productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
