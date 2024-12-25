using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockManagementSystem.DomainModels;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsManager iproductManager;
        public ProductsController(IProductsManager products)
        {
            this.iproductManager = products;
        }
        [HttpPost]
        [Route("/register")]
        public async Task<StockManagementResponse<Product>> AddProduct(Product product)
        {
            //if (product == null) // ModelState validation
            //{
            //    return new StockManagementResponse<Product>() { errorMessage = ModelState.ToString() };  // Return validation errors
            //}

            if (product == null) 
            {
                throw new ArgumentNullException(nameof(product));
            }
            var result = await iproductManager.RegisterProductAsync(product);
            return new StockManagementResponse<Product>() { ResultData = result, isSuccessful = true, errorMessage = " " };
        }

        [HttpPut]
        [Route("/update")]
        public async Task<Product> UpdateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            var result = await iproductManager.UpdateProductAsync(product);
            return result;
        }
        [HttpGet]
        [Route("/all")]
        public List<Product> GetAllProductsAsync()
        {
             var result = iproductManager.GetAllProductsAsync();
            if(result.Count <1)
            {
                List<Product> nullresult = new List<Product>();

                nullresult.Add(new Product() { productID = -4 });
                return nullresult;
            }
            return result;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<Product> GetProduct(int id)
        {
            var result = await iproductManager.GetProductById(id);
            if (result == null)
            {
                Product nullresult = new Product(){ productID = -4 };
                return nullresult;
            }
            return result;
        }
    }
}
