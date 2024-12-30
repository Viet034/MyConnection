namespace ConnectMySql.Model.DTO.Request.ProductRequest;

public class ProductCreate
{

    public string Name { get; set; }
    public decimal Price { get; set; }

    public ProductCreate(string name, decimal price)
    {
        Name = name;
        Price = price;
    }


}
