using NyvaaSilksEcommerce.DataAccess;
using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public ProductCategoryRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public async Task<IEnumerable<ProductCategoryfromDB>> GetProductCategoryfromDBAsync()
        {
            string productCategoryQuery = "Select Prod.ProductName as ProductName " +
                ",ProdCat.ProductCategoryName as ProductCategoryName,ProdCat.ProductCategoryId as ProductCategoryId from ProductType prod" +
                " inner join ProductCategory ProdCat on prod.ProductId = ProdCat.ProductID";
            var ProductCategoryfromDB = new List<ProductCategoryfromDB>();
            using (var reader = await _databaseHelper.ExecuteQueryAsync(productCategoryQuery))
            {
                while (await reader.ReadAsync())
                {
                    var productCategoryDB = new ProductCategoryfromDB
                    {
                        ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"]),
                        ProductType = reader["ProductName"].ToString(),
                        CategoryName = reader["ProductCategoryName"].ToString()
                    };
                    ProductCategoryfromDB.Add(productCategoryDB);
                }
                return ProductCategoryfromDB;
            }

        }
    }
}
