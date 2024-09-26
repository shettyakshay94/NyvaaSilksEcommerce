using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Manager
{
    public interface IAdminManager
    {
       Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task<IEnumerable<ProductCategory>> getProductCategory(int id);
        Task<int> SaveProductDetails(ProductDetails productDetails);
        Task<bool> SaveProductImage(ProductImage productImage);
    }
}
