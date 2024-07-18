using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Application.Commands.AddProductImage
{
    public class AddProductImageCommand : IRequest<ProductImage>
    {
        public AddProductImageCommand(byte[] bytesImage, int productId, string imageName)
        {
            BytesImage = bytesImage;
            ProductId = productId;
            ImageName = imageName;
        }
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }

    }
}
