using Shopping.Domain.Reponses.Category;
using Shopping.Domain.Requests.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.DAL.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Gets();
        Task<Category> GetCategoryById(int categoryId);
        Task<CreateCategoryRes> CreateCategory(CreateCategoryReq request);
        Task<EditCategoryRes> EditCategory(EditCategoryReq request);
        Task<DeleteCategoryRes> DeleteCategory(int categoryId);
    }
}
