using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Application.Commands.AddBatch
{
    public class AddBatchInputModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
