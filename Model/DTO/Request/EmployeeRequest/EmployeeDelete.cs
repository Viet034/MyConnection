namespace ConnectMySql.Model.DTO.Request.EmployeeRequest;

public class EmployeeDelete
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }

    public EmployeeDelete(int employeeId, string employeeName, DateTime dob, string gender)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Dob = dob;
        Gender = gender;
    }
}
