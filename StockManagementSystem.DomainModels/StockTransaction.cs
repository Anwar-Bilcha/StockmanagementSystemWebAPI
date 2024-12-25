using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DomainModels
{
    public class StockTransaction
    {
        public int transactionNumber { get; set; }
        public int transactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string transactionName { get; set; } = string.Empty;
        public string transactionType { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> Items { get; set; }
        public Customer Customer { get; set; }

        public StockTransaction() { }
    }
}
