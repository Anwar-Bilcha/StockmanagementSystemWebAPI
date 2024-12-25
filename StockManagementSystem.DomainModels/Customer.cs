namespace StockManagementSystem.DomainModels
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PartyAddress Address { get; set; }
        public List<Product> FrequentlyPurchaseList { get; set; }
        public Customer()
        {
            
        }

    }
}