namespace ConnectMySql.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public Order()
        {
        }

        public Order(int orderId, DateTime orderDate, int customerId, Customer customer)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerId = customerId;
            Customer = customer;
            //OrderDetails = orderDetails ?? new List<OrderDetail>();
        }
    }
}
