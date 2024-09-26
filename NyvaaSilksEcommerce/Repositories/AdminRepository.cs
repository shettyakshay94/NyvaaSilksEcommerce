using NyvaaSilksEcommerce.DataAccess;
using NyvaaSilksEcommerce.Models;
using System.Data.SqlClient;

namespace NyvaaSilksEcommerce.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public AdminRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public async Task<IEnumerable<ProductType>> getProductTypeFromRepository()
        {
            string ProductTypeQuery = "SELECT ProductId,ProductName FROM ProductType";
            var productTypes = new List<ProductType>();

            using (var reader = await _databaseHelper.ExecuteQueryAsync(ProductTypeQuery))
            {
                while (await reader.ReadAsync())
                {
                    var productType = new ProductType
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString()
                    };
                    productTypes.Add(productType);
                }
            }

            return productTypes;
        }


        public async Task<IEnumerable<ProductCategory>> getProductCategoryFromRepository(int id)
        {
            string ProductTypeQuery = "SELECT ProductCategoryId,ProductCategoryName FROM ProductCategory where ProductID = @ProductID";
            var productTypes = new List<ProductCategory>();
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@ProductID", id)
           };
            using (var reader = await _databaseHelper.ExecuteQueryAsync(ProductTypeQuery, parameters))
            {
                while (await reader.ReadAsync())
                {
                    var productType = new ProductCategory
                    {
                        ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"]),
                        ProductCategoryName = reader["ProductCategoryName"].ToString()
                    };
                    productTypes.Add(productType);
                }
            }

            return productTypes;
        }

        public async Task<int> SaveProductDetails(ProductDetails productDetails)
        {
            // SQL query to insert the record and return the new ID
            string query = @"
INSERT INTO Products (ProductName, ProductDescription, ProductId, ProductCategoryId, ProductAmount)
OUTPUT INSERTED.Id
VALUES (@ProductName, @ProductDescription, @ProductId, @ProductCategoryId, @ProductAmount)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ProductName", productDetails.ProductName),
        new SqlParameter("@ProductDescription", productDetails.ProductDescription),
        new SqlParameter("@ProductId", productDetails.ProductId),
        new SqlParameter("@ProductCategoryId", productDetails.ProductCategoryId),
        new SqlParameter("@ProductAmount", productDetails.ProductAmount)
            };

            // Execute the query and return the inserted ID
            object result = await _databaseHelper.ExecuteScalarAsync(query, parameters);

            // Convert result to int (assuming ID is of int type)
            return Convert.ToInt32(result);
        }
        public async Task<bool> SaveProductImage(ProductImage productImage)
        {
            string query = @"
    INSERT INTO ProductImages (ImageName, FileLocation, ProductsId)
    VALUES (@ImageName, @FileLocation, @ProductsId)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ImageName", productImage.ImageName),
        new SqlParameter("@FileLocation", productImage.FileLocation),
        new SqlParameter("@ProductsId", productImage.ProductsId)
            };

            int rowsAffected = await _databaseHelper.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }

    }
}

