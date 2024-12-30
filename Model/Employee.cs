namespace ConnectMySql.Model;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public Employee()
    {
    }

    public Employee(int employeeId, string employeeName, DateTime dob, string gender)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Dob = dob;
        Gender = gender;
        //Orders = orders ?? new List<Order>();
    }
}
