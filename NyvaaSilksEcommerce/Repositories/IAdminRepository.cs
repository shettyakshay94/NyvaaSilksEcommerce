using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<ProductType>> getProductTypeFromRepository();
        Task<IEnumerable<ProductCategory>> getProductCategoryFromRepository(int id);
        Task<int> SaveProductDetails(ProductDetails productDetails);
        Task<bool> SaveProductImage(ProductImage productImage);
    }
}
