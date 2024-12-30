using ConnectMySql.DB;
using ConnectMySql.Model.DTO;
using ConnectMySql.Model;
using Microsoft.AspNetCore.Mvc;
using ConnectMySql.Service;
using ConnectMySql.Model.DTO.Request.OrderRequest;

namespace ConnectMySql.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrderV2Controller : ControllerBase
{
    private readonly IOrderService _service;

    public OrderV2Controller(IOrderService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public IActionResult AddOrder([FromBody] OrderCreate create)
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


    [HttpPut("update/{id}")]
    public IActionResult Update(int id, [FromBody] OrderUpdate update)
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
    public IActionResult DeleteOrder(int id)
    {
        try
        {
            var response = _service.Delete(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("find/{id}")]
    public IActionResult FindById(int id)
    {
        try
        {
            var response = _service.FinById(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
