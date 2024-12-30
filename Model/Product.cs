namespace ConnectMySql.Model;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public Product()
    {
    }

    public Product(int productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price; 
    }
}
