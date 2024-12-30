namespace ConnectMySql.Model.DTO.Response.CustomerResponse;

public class CustomerResponse
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public CustomerResponse()
    {
    }

    public CustomerResponse(int customerId, string fullName, int age, string phone, string address)
    {
        CustomerId = customerId;
        FullName = fullName;
        Age = age;
        Phone = phone;
        Address = address;
    }
}
