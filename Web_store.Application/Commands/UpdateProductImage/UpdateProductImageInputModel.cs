namespace Web_store.Application.Commands.UpdateProductImage
{
    public class UpdateProductImageInputModel
    {
        public int Id { get; set; }
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
    }
}
