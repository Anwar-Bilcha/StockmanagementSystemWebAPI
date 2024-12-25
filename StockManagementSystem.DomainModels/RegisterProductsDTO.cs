using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DomainModels
{
    public class RegisterProductsDTO : Product
    {
        public string productName { get; set; } = string.Empty;
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public int productCategoryID { get; set; }

        public string productCategoryName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public RegisterProductsDTO(string name, string desc, string categ, int catId, string catName, decimal quan, decimal unitP, decimal p)
        {
            productName = name;
            productDescription = desc;
            productCategory = categ;
            productCategoryID = catId;
            productCategoryName = catName;
            Quantity = quan;
            UnitPrice = unitP;
            Price = p;
        }
    }
}
