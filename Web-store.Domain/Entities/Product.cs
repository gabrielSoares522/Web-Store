using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_store.Domain.Entities
{
    public class Product
    {
        public Product(int id, string name, string description, double value, int quantity, bool isAvailable,int storeId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            Quantity = quantity;
            IsAvailable = isAvailable;
            StoreId = storeId;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public int StoreId {  get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        public List<Batch> Batchs { get; set;}
        public List<ProductImage> ProductImages { get; set;}

    }
}
