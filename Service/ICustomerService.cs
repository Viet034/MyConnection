using ConnectMySql.Model.DTO.Request.CustomerRequest;
using ConnectMySql.Model.DTO.Request.ProductRequest;
using ConnectMySql.Model.DTO.Response.CustomerResponse;
using ConnectMySql.Model.DTO.Response.ProductResponse;

namespace ConnectMySql.Service;

public interface ICustomerService
{
    public List<CustomerResponse> GetAll();
    public CustomerResponse Add(CustomerCreate create);
    public CustomerResponse Update(int id, CustomerUpdate update);
    public CustomerResponse FindById(int id);
    public bool Delete(int id);

}
