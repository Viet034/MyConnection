using ConnectMySql.Model.DTO.Request.ProductRequest;
using ConnectMySql.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConnectMySql.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductV2Controller : ControllerBase
{

    private readonly IProductService _service;

    public ProductV2Controller(IProductService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] ProductCreate create)
    {
        try
        {
            var response = _service.Add(create);
            return Ok(response);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public IActionResult Update(int id,[FromBody] ProductUpdate update)
    {
        try
        {
            var response = _service.Update(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
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
            return BadRequest(ex.ToString());
        }
    }

    [HttpGet("getall")]
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
    [HttpDelete("delete")]
    public IActionResult Delete(int id)
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
