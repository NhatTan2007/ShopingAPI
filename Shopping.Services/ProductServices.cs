using Shopping.BAL.Interface;
using Shopping.DAL.Interface;
using Shopping.Domain.Reponses.Product;
using Shopping.Domain.Requests.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BAL.Implement
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductRes> CreateProduct(CreateProductReq request)
        {
            return await _productRepository.CreateProduct(request);
        }

        public async Task<DeleteProductRes> DeleteProduct(string productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }

        public async Task<EditProductRes> EditProduct(EditProductReq request)
        {
            return await _productRepository.EditProduct(request);
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        public async Task<IEnumerable<Product>> Gets()
        {
            return await _productRepository.Gets();
        }

        public async Task<RestoreProductRes> RestoreProduct(string productId)
        {
            return await _productRepository.RestoreProduct(productId);
        }
    }
}
