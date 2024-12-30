using ConnectMySql.Model.DTO.Request.CustomerRequest;
using ConnectMySql.Model.DTO.Request.EmployeeRequest;
using ConnectMySql.Model.DTO.Response.CustomerResponse;
using ConnectMySql.Model.DTO.Response.EmployeeResponse;

namespace ConnectMySql.Service;

public interface IEmployeeService
{
    public List<EmployeeResponse> GetAll();
    public EmployeeResponse Add(EmployeeCreate create);
    public EmployeeResponse Update(int id, EmployeeUpdate update);
    public EmployeeResponse FindById(int id);
    public bool Delete(int id);

}
