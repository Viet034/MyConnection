using ConnectMySql.Controllers;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.ProductRequest;
using ConnectMySql.Model.DTO.Response.ProductResponse;

namespace ConnectMySql.Mapper;

public interface IProductMapper
{
    // request => entity
    public Product CreateToEntity(ProductCreate create);
    public Product UpdateToEntity(ProductUpdate update);
    public Product DeleteToEntity(ProductDelete delete);

    // entity => response
    public ProductResponse EntityToResponse(Product entity);
    public List<ProductResponse> ListEntityToListResponse(List<Product> entity);
}
