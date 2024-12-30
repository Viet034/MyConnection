using ConnectMySql.Model.DTO.Request.EmployeeRequest;


namespace ConnectMySql.Model.DTO.Response.EmployeeResponse;

public class EmployeeResponse
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }

    public EmployeeResponse()
    {
    }

    public EmployeeResponse(int employeeId, string employeeName, DateTime dob, string gender)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Dob = dob;
        Gender = gender;
    }
}
