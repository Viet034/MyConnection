namespace ConnectMySql.Model.DTO.Response.ProductResponse;

public class ProductResponse
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ProductResponse()
    {
    }

    public ProductResponse(int productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}
