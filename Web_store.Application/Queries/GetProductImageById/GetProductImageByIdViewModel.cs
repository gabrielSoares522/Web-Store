using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Queries.GetProductImageById
{
    public class GetProductImageByIdViewModel
    {
        public GetProductImageByIdViewModel(int id, byte[] bytesImage, int productId, string imageName,DateTime createAt, DateTime updateAt)
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
