using Shopping.Domain.Reponses.Product;
using Shopping.Domain.Requests.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BAL.Interface
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> Gets();
        Task<Product> GetProductById(string productId);
        Task<CreateProductRes> CreateProduct(CreateProductReq request);
        Task<EditProductRes> EditProduct(EditProductReq request);
        Task<DeleteProductRes> DeleteProduct(string productId);
        Task<RestoreProductRes> RestoreProduct(string productId);
    }
}
