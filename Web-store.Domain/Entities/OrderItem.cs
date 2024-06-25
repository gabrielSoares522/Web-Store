using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_store.Domain.Entities
{
    public class OrderItem
    {

        public OrderItem(int id, int orderId, int productId, int quantity)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
