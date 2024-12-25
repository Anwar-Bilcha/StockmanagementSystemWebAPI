namespace StockManagementSystem.DomainModels
{
    public class PartyAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } 
        public string Country { get; set; } = string.Empty;
        public PartyAddress()
        {
            
        }
    }
}