using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Domain.Entities
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public Batch(int id, int productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}
