using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NyvaaSilksEcommerce.Manager;
using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminManager _adminManager;
        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var products = await _adminManager.GetProductTypesAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string ProductName, [FromQuery] string ProductCategoryName)
        {
            Console.WriteLine($"ProductName: {ProductName}, ProductCategoryName: {ProductCategoryName}");

            var products = await _adminManager.SearchProducts(ProductName, ProductCategoryName);
            return Ok(products);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("getProductsCategory/{productId}")]
        public async Task<IActionResult> GetProductsCatgoryAsync(int productId)
        {
            try
            {
                var products = await _adminManager.getProductCategory(productId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("uploadproduct")]
        public async Task<IActionResult> UploadProductDetails([FromBody] ProductDetails productDetails)
        {
            try
            {
                var productSaved = await _adminManager.SaveProductDetails(productDetails);
                return Ok(productSaved);
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

        [HttpPost("uploadproductimages")]
        public async Task<IActionResult> UploadProductImages([FromForm] ProductDetails productDetails, [FromForm] List<IFormFile> files)
        {
            try
            {
                // Save the product details and retrieve the ProductId (assuming this returns the inserted product's ID)
                int productId = await _adminManager.SaveProductDetails(productDetails);

                // Check if files are uploaded
                if (files != null && files.Count > 0)
                {
                    // Loop through each uploaded file
                    foreach (var file in files)
                    {
                        // Ensure the file is not empty
                        if (file.Length > 0)
                        {
                            // Define file save path (you can customize this as needed)
                            var filePath = Path.Combine("wwwroot/uploads", file.FileName);

                            // Save the file locally
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            // Save image info into the database
                            var productImage = new ProductImage
                            {
                                ImageName = file.FileName,
                                FileLocation = filePath,  // You can also store just relative path if necessary
                                ProductsId = productId    // Associate with the saved product ID
                            };

                            await _adminManager.SaveProductImage(productImage);
                        }
                    }
                }

                return Ok(new { ProductId = productId, Message = "Product and images uploaded successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
