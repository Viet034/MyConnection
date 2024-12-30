namespace ConnectMySql.Model.DTO.Request.EmployeeRequest;

public class EmployeeUpdate
{

    public string EmployeeName { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }

    public EmployeeUpdate(string employeeName, DateTime dob, string gender)
    {
        EmployeeName = employeeName;
        Dob = dob;
        Gender = gender;
    }
}
