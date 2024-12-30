namespace ConnectMySql.Model.DTO.Request.ProductRequest;

public class ProductDelete
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ProductDelete(int productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}
