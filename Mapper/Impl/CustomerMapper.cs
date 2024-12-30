using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.CustomerRequest;
using ConnectMySql.Model.DTO.Response.CustomerResponse;

namespace ConnectMySql.Mapper.Impl;

public class CustomerMapper : ICustomerMapper
{
    public CustomerResponse EntityToResponse(Customer entity)
    {
        CustomerResponse response = new CustomerResponse();
        response.CustomerId = entity.CustomerId;
        response.FullName = entity.FullName;
        response.Age = entity.Age;
        response.Phone = entity.Phone;
        response.Address = entity.Address;
        return response;
    }

    public List<CustomerResponse> ListEntityToResponse(List<Customer> entity)
    {
        return entity.Select(c => EntityToResponse(c)).ToList();
    }

    public Customer CreateToEntity(CustomerCreate create)
    {
        Customer entity = new Customer();
        entity.FullName = create.FullName;
        entity.Age = create.Age;
        entity.Phone = create.Phone;
        entity.Address = create.Address;
        return entity;
    }

    public Customer UpdateToEntity(CustomerUpdate update)
    {
        Customer entity = new Customer();
        entity.FullName = update.FullName;
        entity.Age = update.Age;
        entity.Phone = update.Phone;
        entity.Address = update.Address;
        return entity;
    }

    public Customer DeleteToEntity(CustomerDelete delete)
    {
        Customer entity = new Customer();
        entity.CustomerId = delete.CustomerId;
        entity.FullName = delete.FullName;
        entity.Age = delete.Age;
        entity.Phone = delete.Phone;
        entity.Address = delete.Address;
        return entity;
    }
}
