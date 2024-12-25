using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DomainModels
{
    public class StockManagementResponse <T> where T : class, new()
    {
        public T ResultData { get; set; }
        public string errorMessage { get; set; }
        public bool isSuccessful { get; set; }
        public StockManagementResponse()
        {
            ResultData = new T();
            errorMessage = string.Empty;
            isSuccessful = true;
        }
    }
}
