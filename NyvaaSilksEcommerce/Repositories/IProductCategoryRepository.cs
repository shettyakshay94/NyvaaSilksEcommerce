using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategoryfromDB>> GetProductCategoryfromDBAsync();
    }
}
