using ConnectMySql.DB;
using Microsoft.AspNetCore.Mvc;

namespace ConnectMySql.Controllers;

[ApiController]
[Route("/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly ApplicationDbContext _database;

    public OrderDetailController(ApplicationDbContext database)
    {
        _database = database;
    }


}
