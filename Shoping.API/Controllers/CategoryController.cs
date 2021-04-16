using Microsoft.AspNetCore.Mvc;
using Shopping.BAL.Interface;
using Shopping.DAL.Interface;
using Shopping.Domain.Reponses.Product;
using Shopping.Domain.Requests.Product;
using Shopping.Domain.Reponses.Category;
using Shopping.Domain.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        /// <summary>
        /// Get all Category is actived
        /// </summary>
        /// <returns>List of Categories</returns>
        [HttpGet("api/category/gets")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _categoryServices.Gets());
        }
        /// <summary>
        /// Get Category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Specific Category has id want to find</returns>
        [HttpGet("api/category/get/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            return Ok(await _categoryServices.GetCategoryById(categoryId));
        }
        /// <summary>
        /// Create new category
        /// </summary>
        /// <param name="request"></param>
        /// <returns>CategoryId of new Category</returns>
        [HttpPost("api/category/create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryReq request)
        {
            return Ok(await _categoryServices.CreateCategory(request));
        }
        /// <summary>
        /// Edit category information
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result of edition</returns>
        [HttpPut("api/category/edit/")]
        public async Task<IActionResult> EditCategory(EditCategoryReq request)
        {
            return Ok(await _categoryServices.EditCategory(request));
        }
        /// <summary>
        /// Delete specific category with Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("api/category/delete/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            return Ok(await _categoryServices.DeleteCategory(categoryId));
        }
    }
}
