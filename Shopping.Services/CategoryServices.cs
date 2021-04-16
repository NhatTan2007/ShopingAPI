using Shopping.BAL.Interface;
using Shopping.DAL.Interface;
using Shopping.Domain.Reponses.Category;
using Shopping.Domain.Requests.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.BAL.Implement
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> Gets()
        {
            return await _categoryRepository.Gets();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _categoryRepository.GetCategoryById(categoryId);
        }

        public async Task<CreateCategoryRes> CreateCategory(CreateCategoryReq request)
        {
            return await _categoryRepository.CreateCategory(request);
        }

        public async Task<EditCategoryRes> EditCategory(EditCategoryReq request)
        {
            return await _categoryRepository.EditCategory(request);
        }

        public async Task<DeleteCategoryRes> DeleteCategory(int categoryId)
        {
            return await _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
