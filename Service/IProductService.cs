using ConnectMySql.Model.DTO.Request.ProductRequest;
using ConnectMySql.Model.DTO.Response.ProductResponse;

namespace ConnectMySql.Service;

public interface IProductService
{
    public List<ProductResponse> GetAll();
    public ProductResponse Add(ProductCreate create);
    public ProductResponse Update(int id, ProductUpdate update);
    public ProductResponse FindById(int id);
    public bool Delete(int id);
    
}
