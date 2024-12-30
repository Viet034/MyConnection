using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.CustomerRequest;
using ConnectMySql.Model.DTO.Response.CustomerResponse;

namespace ConnectMySql.Mapper
{
    public interface ICustomerMapper
    {
        //request => entity 
        public Customer CreateToEntity(CustomerCreate create);
        public Customer UpdateToEntity(CustomerUpdate update);
        public Customer DeleteToEntity(CustomerDelete delete);

        //entity => response
        public CustomerResponse EntityToResponse(Customer entity);
        public List<CustomerResponse> ListEntityToResponse(List<Customer> entity);
    }
}
