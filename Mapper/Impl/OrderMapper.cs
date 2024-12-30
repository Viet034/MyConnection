using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.OrderRequest;
using ConnectMySql.Model.DTO.Response.OrderResponse;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConnectMySql.Mapper.Impl;

public class OrderMapper : IOrderMapper
{
    public Order CreateToEntity(OrderCreate create)
    {
        Order order = new Order();
        order.OrderDate = create.OrderDate;
        order.ShipAddress = create.ShipAddress;
        order.ShipCity = create.ShipCity;
        order.Status = create.Status;
        order.CustomerId = create.CustomerId;
        order.EmployeeId = create.EmployeeId;
        return order;
    }

    public Order DeleteToEntity(OrderDelete delete)
    {
        Order order = new Order();
        order.OrderId = delete.OrderId;
        order.OrderDate = delete.OrderDate;
        order.ShipAddress = delete.ShipAddress;
        order.ShipCity = delete.ShipCity;
        order.Status = delete.Status;
        order.CustomerId = delete.CustomerId;
        order.EmployeeId = delete.EmployeeId;
        return order;
    }

    public OrderResponse EntityToResponse(Order entity)
    {
        OrderResponse response = new OrderResponse();
        response.OrderId = entity.OrderId;
        response.OrderDate = entity.OrderDate;
        response.ShipAddress = entity.ShipAddress;
        response.ShipCity = entity.ShipCity;
        response.Status = entity.Status;
        response.CustomerId = entity.CustomerId;
        response.EmployeeId = entity.EmployeeId;
        return response;
    }

    public List<OrderResponse> ListEntityToResponse(List<Order> entity)
    {
        return entity.Select(o => EntityToResponse(o)).ToList();
    }

    public Order UpdateToEntity(int id, OrderUpdate update)
    {
        Order order = new Order();
        order.OrderDate = update.OrderDate;
        order.ShipAddress = update.ShipAddress;
        order.ShipCity = update.ShipCity;
        order.Status = update.Status;
        order.CustomerId = update.CustomerId;
        order.EmployeeId = update.EmployeeId;
        return order;
    }
}
