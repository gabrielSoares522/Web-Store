using MediatR;

namespace Web_store.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest<Unit>
    {
        public UpdateProductCommand(int id, string name,string description, double value,int quantity,bool isAvailable, int storeId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            Quantity = quantity;
            IsAvailable = isAvailable;
            StoreId = storeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public int StoreId { get; set; }
    }
}
