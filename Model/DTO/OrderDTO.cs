using System.ComponentModel.DataAnnotations;

namespace ConnectMySql.Model.DTO;

public class OrderDTO
{
    [Required]
    public DateTime OrderDate { get; set; }

    [Required, MaxLength(100)]
    public string ShipAddress { get; set; }

    [Required, MaxLength(100)]
    public string ShipCity { get; set; }
    
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [EnumDataType(typeof(OrderStatus))]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}
