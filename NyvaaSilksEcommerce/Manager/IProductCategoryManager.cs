using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Manager
{
    public interface IProductCategoryManager
    {
        Task<IEnumerable<ProductAndCategory>> GetProductCategories();
    }
}
