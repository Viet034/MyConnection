using ConnectMySql.DB;
using ConnectMySql.Mapper;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.CustomerRequest;
using ConnectMySql.Model.DTO.Response.CustomerResponse;

namespace ConnectMySql.Service.Impl;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbContext;
    private ICustomerMapper _mapper;

    public CustomerService(ApplicationDbContext dbContext, ICustomerMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public CustomerResponse Add(CustomerCreate create)
    {
        //b1: request => entity
        Customer entity = _mapper.CreateToEntity(create);
        //b2: luu vao db
        var result = _dbContext.Customers.Add(entity).Entity;
        _dbContext.SaveChanges();
        //b3: entity => request
        var response = _mapper.EntityToResponse(result);
        return response;
    }

    public bool Delete(int id)
    {
        var cusId = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);

        if(cusId == null) throw new Exception($"Khong ton tai co ID {id}");

        _dbContext.Customers.Remove(cusId);
        _dbContext.SaveChanges();
        return true;
    }

    public CustomerResponse FindById(int id)
    {
        var cusId = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);

        if(cusId == null) throw new Exception("Khong co ban ghi nao ton tai");

        var response = _mapper.EntityToResponse(cusId);
        return response;
    }

    public List<CustomerResponse> GetAll()
    {
        var result = _dbContext.Customers.ToList();

        if (result.Count == 0) throw new Exception("Khong co ban ghi nao ton tai");
        
        var response = _mapper.ListEntityToResponse(result).ToList();

        return response;
    }

    public CustomerResponse Update(int id, CustomerUpdate update)
    {
        var cusId = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);

        if(cusId == null) throw new Exception("Khong co ban ghi nao ton tai");
        
        var result = _mapper.UpdateToEntity(update);
        cusId.FullName = update.FullName;
        cusId.Age = update.Age;
        cusId.Phone = update.Phone;
        cusId.Address = update.Address;
        _dbContext.SaveChanges();

        var response = _mapper.EntityToResponse(result);
        return response;
    }
}
