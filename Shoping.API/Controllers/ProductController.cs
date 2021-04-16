using Microsoft.AspNetCore.Mvc;
using Shopping.BAL.Interface;
using Shopping.Domain.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        /// <summary>
        /// Get all Product is actived
        /// </summary>
        /// <returns>List all Products</returns>
        [HttpGet("api/Product/gets")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _productServices.Gets());
        }
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/Product/get/{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            return Ok(await _productServices.GetProductById(productId));
        }
        /// <summary>
        /// Create new Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ProductId of new Product</returns>
        [HttpPost("api/Product/create")]
        public async Task<IActionResult> CreateProduct(CreateProductReq request)
        {
            return Ok(await _productServices.CreateProduct(request));
        }
        /// <summary>
        /// Edit Product information
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result of edition</returns>
        [HttpPut("api/Product/edit/")]
        public async Task<IActionResult> EditProduct(EditProductReq request)
        {
            return Ok(await _productServices.EditProduct(request));
        }

        /// <summary>
        /// Restore specific Product with Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Result of restore product action</returns>
        [HttpPost("api/Product/restore/{productId}")]
        public async Task<IActionResult> RestoreProduct(string productId)
        {
            return Ok(await _productServices.RestoreProduct(productId));
        }

        /// <summary>
        /// Delete specific Product with Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("api/Product/delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            return Ok(await _productServices.DeleteProduct(productId));
        }

    }
}
