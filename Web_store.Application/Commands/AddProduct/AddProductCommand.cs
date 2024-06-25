using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Application.Commands.AddProduct
{
    public class AddProductCommand: IRequest<Unit>
    {
        public AddProductCommand(string name,string description, double value,int quantity,bool isAvailable,int storeId)
        {
            Name = name;
            Description = description;
            Value = value;
            Quantity = quantity;
            IsAvailable = isAvailable;
            StoreId = storeId;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public int StoreId { get; set; }
    }
}
