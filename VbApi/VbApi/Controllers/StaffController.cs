using Microsoft.AspNetCore.Mvc;
using VbApi.Models;
namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    public StaffController()
    {
    }

    [HttpPost]
    public Staff Post([FromBody] Staff value)
    {
        return value;
    }
}