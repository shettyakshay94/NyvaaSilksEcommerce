using NyvaaSilksEcommerce.Models;
using NyvaaSilksEcommerce.Repositories;

namespace NyvaaSilksEcommerce.Manager
{
    public class ProductCategoryManager :IProductCategoryManager
    {
        private readonly IProductCategoryRepository _repository;
        public ProductCategoryManager(IProductCategoryRepository productCategoryRepository) { 
        _repository = productCategoryRepository;
        }
        public async Task<IEnumerable<ProductAndCategory>> GetProductCategories()
        {
            // Get the product categories from the repository
            var productCategoriesFromDB = await _repository.GetProductCategoryfromDBAsync();

            if (productCategoriesFromDB == null || !productCategoriesFromDB.Any())
            {
                return Enumerable.Empty<ProductAndCategory>();
            }

            // Create a dictionary to group products by product name
            var productAndCategoriesDictionary = new Dictionary<string, ProductAndCategory>();

            foreach (var item in productCategoriesFromDB)
            {
                // Check if the product already exists in the dictionary
                if (!productAndCategoriesDictionary.ContainsKey(item.ProductType))
                {
                    // If not, create a new ProductAndCategory entry
                    productAndCategoriesDictionary[item.ProductType] = new ProductAndCategory
                    {
                        ProductName = item.ProductType,
                        ProductCategory = new List<Category>()
                    };
                }

                // Add the category to the product's category list
                var productAndCategory = productAndCategoriesDictionary[item.ProductType];
                var category = new Category
                {
                    ProductCategoryId = item.ProductCategoryId,
                    CategoryName = item.CategoryName
                };
                ((List<Category>)productAndCategory.ProductCategory).Add(category);
            }

            // Return the dictionary values as the final result
            return productAndCategoriesDictionary.Values;
        }

    }
}
