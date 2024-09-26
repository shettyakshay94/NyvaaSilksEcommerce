namespace NyvaaSilksEcommerce.Models
{
    public class ProductDetails
    {
      public int  ProductId {  get; set; }
      public int ProductCategoryId {  get; set; }
      public string ProductName { get; set; } 
      public string ProductDescription { get; set; }
      public string ProductAmount { get; set; }
    }

    public class ProductContentDetails
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageName { get; set; }

    }
}
