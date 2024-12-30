using ConnectMySql.Model.DTO.Request.EmployeeRequest;
using ConnectMySql.Model.DTO.Request.OrderRequest;
using ConnectMySql.Model.DTO.Response.EmployeeResponse;
using ConnectMySql.Model.DTO.Response.OrderResponse;

namespace ConnectMySql.Service;

public interface IOrderService
{
    public List<OrderResponse> GetAll();
    public OrderResponse Add(OrderCreate create);
    public OrderResponse Update(int id,OrderUpdate update);
    public bool Delete(int id);
    public OrderResponse FinById(int id);
}
