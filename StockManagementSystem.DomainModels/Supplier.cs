using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DomainModels
{
    public class Supplier
    {
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public PartyAddress Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; } = string.Empty;
        public List<Product> suppliesProducts { get; set; }
    }
}
