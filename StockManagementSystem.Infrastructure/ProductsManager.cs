using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DomainModels;
using StockManagementSystem;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.Infrastructure;

public class ProductsManager : IProductsManager
{
    private readonly ApplicationDbContext context;
    public ProductsManager(ApplicationDbContext appContext)
    {
        context = appContext;
        
    }
    async Task<Product>  IProductsManager.DeleteProductAsync(int productId)
    {
        var productToDelete = context.Products.Find(productId);
        if(productToDelete == null)
        {
            return new Product();
        }
        await context.Products.Remove(productToDelete).ReloadAsync();
        context.SaveChanges();
        return productToDelete;
    }

    List<Product> IProductsManager.GetAllProductsAsync()
    {
        return context.Products.Take(10).ToList();
    }

    async Task<Product> IProductsManager.GetProductById(int productId)
    {
        
        var result = await context.Products.FindAsync(productId);
        return result;

    }

    async Task<Product> IProductsManager.GetProductByName(string productName)
    {
        var result = await context.Products.FirstAsync(a => a.productName == productName);
        return result;
    }

    Product IProductsManager.RegisterProduct(Product product)
    {
        RegisterProductsDTO productDTO = new RegisterProductsDTO(product.productName, product.productDescription, product.productCategory, product.productCategoryID, product.productCategoryName, product.Quantity, product.UnitPrice, product.Price);
        context.Products.Add(productDTO);
        context.SaveChanges();
        return product;
    }

   async Task<Product> IProductsManager.RegisterProductAsync(Product product)
    {
        var result = await context.Products.AddAsync(product);
       await context.SaveChangesAsync();
        return product;
    }
   async Task<Product> IProductsManager.UpdateProductAsync(Product product)
    {
        var exsistingProduct = await context.Products.FirstOrDefaultAsync(a=>a.productID==product.productID);
        if (exsistingProduct == null)
        {
            return new Product();
        }
        exsistingProduct.productName = product.productName;
        exsistingProduct.productCategoryName = product.productCategoryName;
        exsistingProduct.productCategory = product.productCategory;
        exsistingProduct.productDescription = product.productDescription;
        exsistingProduct.UnitPrice = product.UnitPrice;
        exsistingProduct.Price = product.Price;
        exsistingProduct.Quantity = product.Quantity;
       await context.SaveChangesAsync();
        return exsistingProduct;
    }
}