namespace ConnectMySql.Model;

public class Customer
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public Customer()
    {
    }

    public Customer(int customerId, string fullName, int age, string phone, string address)
    {
        CustomerId = customerId;
        FullName = fullName;
        Age = age;
        Phone = phone;
        Address = address;
        //Orders = orders ?? new List<Order>();
    }
}
