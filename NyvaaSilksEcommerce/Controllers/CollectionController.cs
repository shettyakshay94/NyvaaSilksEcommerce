using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvaaSilksEcommerce.Manager;

namespace NyvaaSilksEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;

        public CollectionController(IProductService productService, IVendorService vendorService)
        {
            _productService = productService;
            _vendorService = vendorService;
        }

        [HttpGet("product-types")]
        public IActionResult GetProductTypes()
        {
            var productTypes = _productService.GetProductTypes();
            var categories = _productService.GetCategories();
            return Ok(new { productTypes, categories });
        }

        [HttpGet("vendors")]
        public IActionResult GetVendors()
        {
            var vendors = _vendorService.GetAllVendors();
            return Ok(vendors);
        }

        [HttpGet("products/search")]
        public IActionResult SearchProducts(string query)
        {
            var products = _productService.SearchProducts(query);
            return Ok(products);
        }

        [HttpPost("collections")]
        public IActionResult SubmitCollection([FromBody] CollectionDto collection)
        {
            // Logic to save the collection
            return Ok(new { message = "Collection created successfully" });
        }
    }

}
