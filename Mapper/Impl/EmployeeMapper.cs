using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.EmployeeRequest;
using ConnectMySql.Model.DTO.Response.EmployeeResponse;

namespace ConnectMySql.Mapper.Impl;

public class EmployeeMapper : IEmployeeMapper
{
    public Employee CreateToEntity(EmployeeCreate create)
    {
        Employee employee = new Employee();
        employee.EmployeeName = create.EmployeeName;
        employee.Dob = create.Dob;
        employee.Gender = create.Gender;
        return employee;
    }

    public Employee DeleteToEnity(EmployeeDelete delete)
    {
        Employee employee = new Employee();
        employee.EmployeeId = delete.EmployeeId;
        employee.EmployeeName = delete.EmployeeName;
        employee.Dob = delete.Dob;
        employee.Gender = delete.Gender;
        return employee;
    }

    public EmployeeResponse EntityToResponse(Employee entity)
    {
        EmployeeResponse response = new EmployeeResponse();
        response.EmployeeId = entity.EmployeeId;
        response.EmployeeName = entity.EmployeeName;
        response.Dob = entity.Dob;
        response.Gender = entity.Gender;
        return response;
    }

    public Employee GetToEntity(EmployeeGet get)
    {
        throw new NotImplementedException();
    }

    public List<EmployeeResponse> ListEntityToResponse(List<Employee> entity)
    {
        return entity.Select(e => EntityToResponse(e)).ToList();  
    }

    public Employee UpdateToEntity(EmployeeUpdate update)
    {
        Employee employee = new Employee();
        employee.EmployeeName= update.EmployeeName;
        employee.Dob = update.Dob;
        employee.Gender = update.Gender;
        return employee;
    }
}
