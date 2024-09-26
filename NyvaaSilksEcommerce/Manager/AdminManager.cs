using NyvaaSilksEcommerce.Models;
using NyvaaSilksEcommerce.Repositories;

namespace NyvaaSilksEcommerce.Manager
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _adminRepository;
        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            try
            {
                var productTypes = await _adminRepository.getProductTypeFromRepository();
                return productTypes; // Return the fetched product types.
            }
            catch (Exception ex)
            {
                // Optionally, log the exception here (e.g., log to a file or monitoring system).
                return Enumerable.Empty<ProductType>(); // Return an empty list in case of an error.
            }
        }
        public async Task<IEnumerable<ProductCategory>> getProductCategory(int id)
        {
            try
            {
                var productTypes = await _adminRepository.getProductCategoryFromRepository(id);
                return productTypes; // Return the fetched product types.
            }
            catch (Exception ex)
            {
                // Optionally, log the exception here (e.g., log to a file or monitoring system).
                return Enumerable.Empty<ProductCategory>(); // Return an empty list in case of an error.
            }
        }
        public async Task<bool> SaveProductImage(ProductImage productImage)
        {
            try
            {
                var productimageInserted = await _adminRepository.SaveProductImage(productImage);
                return productimageInserted;
            }
            catch (Exception ex) {
                return false;
            }
        }
        public async Task<int> SaveProductDetails(ProductDetails productDetails)
        {
            try
            {
                var productDetailsSaved = await _adminRepository.SaveProductDetails(productDetails);
                return productDetailsSaved;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
