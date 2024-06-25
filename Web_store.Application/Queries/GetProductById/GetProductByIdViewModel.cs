using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Queries.GetProductById
{
    public class GetProductByIdViewModel
    {
        public GetProductByIdViewModel(int id, string name, string description, double value, int quantity, bool isAvailable, DateTime createdAt, DateTime updateAt, int storeId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            Quantity = quantity;
            IsAvailable = isAvailable;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            StoreId = storeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int StoreId { get; set; }
    }
}
