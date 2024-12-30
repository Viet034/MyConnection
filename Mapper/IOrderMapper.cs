using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.OrderRequest;
using ConnectMySql.Model.DTO.Response.OrderResponse;

namespace ConnectMySql.Mapper;

public interface IOrderMapper
{
    //request => entity
    public Order CreateToEntity(OrderCreate create);
    public Order UpdateToEntity(int id, OrderUpdate update);
    public Order DeleteToEntity(OrderDelete delete);
    //entity => response
    public OrderResponse EntityToResponse(Order entity);
    public List<OrderResponse> ListEntityToResponse(List<Order> entity);
}
