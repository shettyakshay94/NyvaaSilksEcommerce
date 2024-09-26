namespace NyvaaSilksEcommerce.Models
{
    public class ProductAndCategory
    {
        public string ProductName { get; set; }
        public IEnumerable<Category> ProductCategory { get; set; }
    }
    public class Category 
    {
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class ProductCategoryfromDB
    {
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductType { get; set; }

    }
}
