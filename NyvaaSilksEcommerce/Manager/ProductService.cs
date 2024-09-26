namespace NyvaaSilksEcommerce.Manager
{
    public class ProductService : IProductService
    {
        //public List<Product> SearchProducts(string query)
        //{

            
        //    // Mock search logic or connect to database
        //    return new List<Product> {
        //    new Product { Name = "Saree 1", Image = "image_url", Description = "A beautiful saree." },
        //    new Product { Name = "Saree 2", Image = "image_url", Description = "Another beautiful saree." }
        //};
        //}

        public List<string> GetProductTypes()
        {
            return new List<string> { "Saree", "Dupatta", "Blouse" };
        }

        public List<string> GetCategories()
        {
            return new List<string> { "Kanjeevaram", "Banarasi", "Cotton" };
        }
    }

}
