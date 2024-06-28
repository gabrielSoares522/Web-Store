using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Web_store.Domain.Entities;

namespace Web_store.Application.Queries.GetProductImages
{
    public class GetProductImagesViewModel
    {
        public GetProductImagesViewModel(int id, byte[] bytesImage, int productId, string imageName, DateTime createAt, DateTime updateAt)
        {
            Id = id;
            BytesImage = bytesImage;
            ProductId = productId;
            ImageName = imageName;
            CreatedAt = createAt;
            UpdateAt = updateAt;
        }

        public int Id { get; set; }
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
