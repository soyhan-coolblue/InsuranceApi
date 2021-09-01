using Insurance.Domain.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Application.Common.Interfaces
{
    public interface IProductApi
    {
        [Get("/products/{id}")]
        Task<Product> GetProduct(int id);
        [Get("/products")]
        Task<List<Product>> GetProducts();
        [Get("/product_types/{id}")]
        Task<ProductType> GetProductsType(int id);
        [Get("/product_types")]
        Task<List<ProductType>> GetProductsTypes();
    }
}
