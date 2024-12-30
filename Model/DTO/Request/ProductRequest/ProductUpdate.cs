namespace ConnectMySql.Model.DTO.Request.ProductRequest;

public class ProductUpdate
{

    public string Name { get; set; }
    public decimal Price { get; set; }

    public ProductUpdate(string name, decimal price)
    {

        Name = name;
        Price = price;
    }
}
