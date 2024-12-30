namespace ConnectMySql.Model.DTO.Request.EmployeeRequest;

public class EmployeeGet
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }

    public EmployeeGet(int employeeId, string employeeName, DateTime dob, string gender)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Dob = dob;
        Gender = gender;
    }
}
