using ConnectMySql.DB;
using ConnectMySql.Mapper;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.EmployeeRequest;
using ConnectMySql.Model.DTO.Request.OrderRequest;
using ConnectMySql.Model.DTO.Response.EmployeeResponse;
using ConnectMySql.Model.DTO.Response.OrderResponse;

namespace ConnectMySql.Service.Impl;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;
    private IOrderMapper _mapper;

    public OrderService(ApplicationDbContext dbContext, IOrderMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public OrderResponse Add(OrderCreate create)
    {
       //b1 request => entity
        Order entity = _mapper.CreateToEntity(create);
        //luu db
        var result = _dbContext.Orders.Add(entity).Entity;
        _dbContext.SaveChanges();
        //entity => response
        var response = _mapper.EntityToResponse(result);
        return response;
    }

    public bool Delete(int id)
    {
        var orId = _dbContext.Orders.FirstOrDefault(o => o.OrderId == id);

        if(orId == null) throw new Exception($"Khong co Order Id {id} nao");
        
        _dbContext.Orders.Remove(orId);
        _dbContext.SaveChanges();
        return true;
    }

    public OrderResponse FinById(int id)
    {
        var orId = _dbContext.Orders.FirstOrDefault(o => o.OrderId == id);

        if (orId == null) throw new Exception($"Khong co Order Id {id} nao");

        var response = _mapper.EntityToResponse(orId);
        return response;
    }

    public List<OrderResponse> GetAll()
    {
        var result = _dbContext.Orders.ToList();

        if(result.Count == 0) throw new Exception($"Khong co Order nao");

        var response = _mapper.ListEntityToResponse(result);
        return response;
    }

    public OrderResponse Update(int id, OrderUpdate update)
    {
        var orId = _dbContext.Orders.FirstOrDefault(o => o.OrderId == id);

        if (orId == null) throw new Exception($"Khong co Order Id {id} nao");
        
        var result = _mapper.UpdateToEntity(id, update);
        orId.OrderDate = update.OrderDate;
        orId.ShipAddress = update.ShipAddress;
        orId.ShipCity = update.ShipCity;
        orId.Status = update.Status;
        orId.CustomerId = update.CustomerId;
        orId.EmployeeId = update.EmployeeId;
        _dbContext.SaveChanges();

        var response = _mapper.EntityToResponse(result);
        return response;
    }
}
