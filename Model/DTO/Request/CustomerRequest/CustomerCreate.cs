using System.ComponentModel.DataAnnotations;

namespace ConnectMySql.Model.DTO.Request.CustomerRequest;

public class CustomerCreate
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public CustomerCreate(string fullName, int age, string phone, string address)
    {
        FullName = fullName;
        Age = age;
        Phone = phone;
        Address = address;
    }
}
