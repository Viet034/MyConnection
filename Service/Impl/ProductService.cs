using ConnectMySql.DB;
using ConnectMySql.Mapper;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.ProductRequest;
using ConnectMySql.Model.DTO.Response.ProductResponse;
using ConnectMySql.Utils;
using System.Text.RegularExpressions;

namespace ConnectMySql.Service.Impl;

public class ProductService : IProductService
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IProductMapper _mapper;

    public ProductService(ApplicationDbContext dbContext, IProductMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ProductResponse Add(ProductCreate create)
    {   
        if(Validator.IsBlank(create.Name))
        {
            throw new Exception("Ten san pham khong duoc bo trong");
        }
        
        if (!Validator.IsCharacter(create.Name))
        {
            throw new Exception("Ten SP k hop le");
        }
        // bước 1: chuyển create sang entity
        Product entity = _mapper.CreateToEntity(create);
        // bước 2: lưu vào DB
        var result = _dbContext.Products.Add(entity).Entity;
        _dbContext.SaveChanges();
        // bước 3: chuyển entity sang response để trả ra
        var response = _mapper.EntityToResponse(result);
        return response;

    }
    public List<ProductResponse> GetAll()
    {
        var result = _dbContext.Products.ToList();

        if(result.Count == 0) throw new Exception("Khong co ban ghi nao ton tai");

        var response = _mapper.ListEntityToListResponse(result).ToList();

        return response;
    }


    public bool Delete(int id)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);

        if(product == null) throw new Exception("Khong co ban ghi nao ton tai");

        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
        return true;
    }

    public ProductResponse FindById(int id)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);

        if( product == null) throw new Exception("Khong co ban ghi nao ton tai");
        
        var response = _mapper.EntityToResponse(product);
        return response;
    }

    
    public ProductResponse Update(int id,ProductUpdate update)
    {
        //b1: tim id san pham 
        var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);

        if(product == null) throw new Exception("Khong co ban ghi nao ton tai");
        
        //b2: request => entity
        var result = _mapper.UpdateToEntity(update);
        product.Name = update.Name;
        product.Price = update.Price;
        _dbContext.SaveChanges();

        //b3: entity => response
        var response = _mapper.EntityToResponse(result);
        return response;
    }
}
