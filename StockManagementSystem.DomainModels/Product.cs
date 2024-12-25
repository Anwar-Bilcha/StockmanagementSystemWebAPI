namespace StockManagementSystem.DomainModels;

public class Product
{
    public int productID { get; set; }
    public string productName { get; set; } = string.Empty;
    public string productDescription { get; set; }
    public string productCategory { get; set; }
    public int productCategoryID { get; set; }

    public string productCategoryName { get; set;} = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Price { get; set; }
    public Product()
    {
        
    }

}
