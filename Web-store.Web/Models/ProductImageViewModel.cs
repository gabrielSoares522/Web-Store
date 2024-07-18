namespace Web_store.Web.Models
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public byte[] BytesImage { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
