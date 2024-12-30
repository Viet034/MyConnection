using ConnectMySql.DB;
using ConnectMySql.Model.DTO;
using ConnectMySql.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectMySql.Service;
using ConnectMySql.Model.DTO.Request.EmployeeRequest;

namespace ConnectMySql.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EmployeeV2Controller : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeV2Controller(IEmployeeService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public IActionResult AddEmployee([FromBody] EmployeeCreate create)
    {
        try
        {
            var response = _service.Add(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        try
        {
            var response = _service.GetAll();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("findId/{id}")]
    public IActionResult FindById(int id)
    {
        try
        {
            var response = _service.FindById(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] EmployeeUpdate update)
    {
        try
        {
            var response = _service.Update(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        try
        {
            var response = _service.Delete(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
