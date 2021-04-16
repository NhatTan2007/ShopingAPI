using Dapper;
using Microsoft.Extensions.Configuration;
using Shopping.DAL.Interface;
using Shopping.Domain.Reponses.Product;
using Shopping.Domain.Requests.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Implement
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(IConfiguration config) : base (config)
        {

        }
        public async Task<CreateProductRes> CreateProduct(CreateProductReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@ProductName", request.ProductName);
            parameters.Add(name: "@Price", request.Price);
            parameters.Add(name: "@CategoryId", request.CategoryId);
            parameters.Add(name: "@Description", request.Description);
            parameters.Add(name: "@Quantity", request.Quantity);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CreateProductRes>(
                                                            cnn: connection,
                                                            sql: "[sp_CreateProduct]",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new CreateProductRes();
                }
            }
        }

        public async Task<DeleteProductRes> DeleteProduct(string productId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@ProductId", productId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<DeleteProductRes>(
                                                            cnn: connection,
                                                            sql: "[sp_SoftDeleteProduct]",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new DeleteProductRes();
                }
            }
        }

        public async Task<EditProductRes> EditProduct(EditProductReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CategoryId", request.CategoryId);
            parameters.Add(name: "@ProductId", request.ProductId);
            parameters.Add(name: "@ProductName", request.ProductName);
            parameters.Add(name: "@Price", request.Price);
            parameters.Add(name: "@Description", request.Description);
            parameters.Add(name: "@Quantity", request.Quantity);
            parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Product>(
                                                            cnn: connection,
                                                            sql: "sp_ModifyProduct",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    EditProductRes editRes = new EditProductRes();
                    editRes.Product = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
                }
                catch (Exception)
                {
                    return new EditProductRes();
                }
            }
        }

        public async Task<Product> GetProductById(string productId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Product>(
                                                cnn: connection,
                                                sql: "sp_GetProductById",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception ex)
                {
                    return new Product();
                }
            }
        }

        public async Task<IEnumerable<Product>> Gets()
        {
            using (var result = SqlMapper.QueryAsync<Product>(cnn: connection,
                                                        sql: "sp_GetProducts",
                                                        commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<Product>();
                }
            }
        }

        public async Task<RestoreProductRes> RestoreProduct(string productId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@ProductId", productId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<RestoreProductRes>(
                                                            cnn: connection,
                                                            sql: "[sp_RestoreProduct]",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new RestoreProductRes();
                }
            }
        }
    }
}
