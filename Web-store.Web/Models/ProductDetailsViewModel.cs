namespace Web_store.Web.Models
{
	public class ProductDetailsViewModel
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public double Value { get; set; }

		public List<ProductImageViewModel> Images { get; set; }
	}
}
