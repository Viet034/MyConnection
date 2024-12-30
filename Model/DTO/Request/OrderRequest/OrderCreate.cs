namespace ConnectMySql.Model.DTO.Request.OrderRequest;

public class OrderCreate
{
    public DateTime OrderDate { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }

    public OrderCreate( DateTime orderDate, string shipAddress, string shipCity, OrderStatus status, int customerId, int employeeId)
    {
        
        OrderDate = orderDate;
        ShipAddress = shipAddress;
        ShipCity = shipCity;
        Status = status;
        CustomerId = customerId;
        EmployeeId = employeeId;
    }
}
