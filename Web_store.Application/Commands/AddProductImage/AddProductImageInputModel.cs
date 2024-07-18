using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.AddProductImage
{
    public class AddProductImageInputModel
    {
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
    }
}
