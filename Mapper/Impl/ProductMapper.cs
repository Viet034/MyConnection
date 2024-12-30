using ConnectMySql.DB;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.ProductRequest;
using ConnectMySql.Model.DTO.Response.ProductResponse;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConnectMySql.Mapper.Impl;

public class ProductMapper : IProductMapper
{

    public Product CreateToEntity(ProductCreate create)
    {
        Product entity = new Product();
        entity.Price = create.Price;
        entity.Name = create.Name.Trim();
        return entity;
    }

    public Product UpdateToEntity(ProductUpdate update)
    {
        Product entity = new Product();
        entity.Price = update.Price;
        entity.Name = update.Name;
        return entity;
    }

    public Product DeleteToEntity(ProductDelete delete)
    {
        Product entity = new Product();
        entity.ProductId = delete.ProductId;
        entity.Name = delete.Name.Trim();
        entity.Price = delete.Price;
        return entity;
    }

    public ProductResponse EntityToResponse(Product entity)
    {
        ProductResponse response = new ProductResponse();
        response.ProductId = entity.ProductId;
        response.Name = entity.Name;
        response.Price = entity.Price;
        return response;
    }

    

    public List<ProductResponse> ListEntityToListResponse (List<Product> entity)
    {
        return entity.Select(x => EntityToResponse(x)).ToList();
    }

    
}
