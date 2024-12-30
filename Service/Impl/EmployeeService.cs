using ConnectMySql.DB;
using ConnectMySql.Mapper;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO.Request.EmployeeRequest;
using ConnectMySql.Model.DTO.Response.EmployeeResponse;

namespace ConnectMySql.Service.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _dbContext;
    private IEmployeeMapper _mapper;

    public EmployeeService(ApplicationDbContext dbContext, IEmployeeMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public EmployeeResponse Add(EmployeeCreate create)
    {
        //request => entity
        Employee enity = _mapper.CreateToEntity(create);
        //luu vao db
        var result = _dbContext.Employees.Add(enity).Entity;
        _dbContext.SaveChanges();
        //entity => resonse
        var response = _mapper.EntityToResponse(result);
        return response;

    }

    public bool Delete(int id)
    {
        var emId = _dbContext.Employees.FirstOrDefault(em => em.EmployeeId == id);

        if (emId == null) throw new Exception($"Khong co Nhan vien Id {id}");
        
        _dbContext.Employees.Remove(emId);
        _dbContext.SaveChanges();
        return true;
    }

    public EmployeeResponse FindById(int id)
    {
        var emId = _dbContext.Employees.FirstOrDefault(em => em.EmployeeId == id);

        if (emId == null) throw new Exception($"Khong co Nhan vien Id {id}");
        
        var response = _mapper.EntityToResponse(emId);
        return response;
    }

    public List<EmployeeResponse> GetAll()
    {
        var em = _dbContext.Employees.ToList();

        if(em.Count == 0) throw new Exception("Khong co ban ghi nao");
        
        var response = _mapper.ListEntityToResponse(em);
        return response;
    }

    public EmployeeResponse Update(int id, EmployeeUpdate update)
    {
        var emId = _dbContext.Employees.FirstOrDefault(em => em.EmployeeId == id);

        if (emId == null) throw new Exception($"Khong co Nhan vien Id {id}");

        var result = _mapper.UpdateToEntity(update);
        emId.EmployeeName = update.EmployeeName;
        emId.Dob = update.Dob;
        emId.Gender = update.Gender;
        _dbContext.SaveChanges(); 

        var response = _mapper.EntityToResponse(result);
        return response;
    }
}
