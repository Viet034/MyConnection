using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.EmployeeRequest;
using ConnectMySql.Model.DTO.Response.EmployeeResponse;
namespace ConnectMySql.Mapper;

public interface IEmployeeMapper
{
    //request => response
    public Employee CreateToEntity(EmployeeCreate create);
    public Employee UpdateToEntity(EmployeeUpdate update);
    public Employee DeleteToEnity(EmployeeDelete delete);
    public Employee GetToEntity(EmployeeGet get);
    //entity => response
    public EmployeeResponse EntityToResponse(Employee entity);
    public List<EmployeeResponse> ListEntityToResponse(List<Employee> entity); 

}
