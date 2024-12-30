using ConnectMySql.DB;
using ConnectMySql.Model;
using ConnectMySql.Model.DTO;
using ConnectMySql.Model.DTO.Request.CustomerRequest;
using ConnectMySql.Model.DTO.Response.CustomerResponse;
using ConnectMySql.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectMySql.Controllers;

[ApiController]
[Route("/api/v2/[controller]")]
public class CustomerV2Controller : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerV2Controller(ICustomerService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public ActionResult<CustomerResponse> AddCustomer([FromBody] CustomerCreate create)
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
        }catch (Exception ex)
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
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateCustomer(int id,[FromBody] CustomerUpdate update)
    {
        try
        {
            var response = _service.Update(id, update);
            return Ok(response);

        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //Can xoa Order truoc roi moi xoa dc Customer (Xoa OrderDetail dau tien)
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        try
        {
            var response = _service.Delete(id);
            return Ok(response);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
