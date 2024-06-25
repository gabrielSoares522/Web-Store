using MediatR;

namespace Web_store.Application.Commands.UpdateProductImage
{
    public class UpdateProductImageCommand : IRequest<Unit>
    {
        public UpdateProductImageCommand(int id, byte[] bytesImage, int productId, string imageName)
        {
            Id = id;
            BytesImage = bytesImage;
            ProductId = productId;
            ImageName = imageName;
        }

        public int Id { get; set; }
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
    }
}
