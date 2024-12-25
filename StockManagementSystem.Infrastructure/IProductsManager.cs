using StockManagementSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Infrastructure
{
    public interface IProductsManager
    {
        Task<Product> GetProductById(int productId);
        Task<Product> GetProductByName(string productName);
        Product RegisterProduct(Product product);
        Task<Product> RegisterProductAsync(Product product);
        Task<Product> DeleteProductAsync(int productId);
        Task<Product> UpdateProductAsync(Product product);
        List<Product> GetAllProductsAsync();
    }
}
