using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_store.Domain.Entities
{
    public class ProductImage
    {
        public ProductImage(int id, byte[] bytesImage, int productId, string imageName) { 
            Id = id;
            BytesImage = bytesImage;
            ProductId = productId;
            ImageName = imageName;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
