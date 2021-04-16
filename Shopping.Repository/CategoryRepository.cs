using Shopping.Domain.Reponses.Category;
using Shopping.Domain.Requests.Category;
using System;
using System.Collections.Generic;
using Dapper;
using Shopping.DAL.Interface;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data;
using Shopping.Domain.Requests;

namespace Shopping.DAL.Implement
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration config) : base (config)
        {

        }
        public async Task<IEnumerable<Category>> Gets()
        {
            using (var result = SqlMapper.QueryAsync<Category>(cnn: connection,
                                                                    sql: "sp_GetCategories",
                                                                    commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<Category>();
                }
            }
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Category>(
                                                cnn: connection,
                                                sql: "sp_GetCategoryById",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception ex)
                {
                    return new Category();
                }
            }
        }

        public async Task<CreateCategoryRes> CreateCategory(CreateCategoryReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CategoryName", request.CategoryName);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CreateCategoryRes>(
                                                            cnn: connection,
                                                            sql: "sp_CreateCategory",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new CreateCategoryRes();
                }
            }
        }

        public async Task<EditCategoryRes> EditCategory(EditCategoryReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CategoryId", request.CategoryId);
            parameters.Add(name: "@CategoryName", request.CategoryName);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<EditCategoryRes>(
                                                            cnn: connection,
                                                            sql: "sp_ModifyCategory",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    var test = await result;
                    return test;
                }
                catch (Exception)
                {
                    return new EditCategoryRes();
                }
            }
        }

        public async Task<DeleteCategoryRes> DeleteCategory(int categoryId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CategoryId", categoryId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<DeleteCategoryRes>(
                                                            cnn: connection,
                                                            sql: "sp_SoftDeleteCategory",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new DeleteCategoryRes();
                }
            }
        }
    }
}
