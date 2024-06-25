using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.UpdateProduct
{
    public class UpdateProductInputModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public int StoreId { get; set; }
    }
}
