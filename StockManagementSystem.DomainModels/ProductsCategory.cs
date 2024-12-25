using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DomainModels
{
    public class ProductsCategory
    {
        
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string Description { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}
