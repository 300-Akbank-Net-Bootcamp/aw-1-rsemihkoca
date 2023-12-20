using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using VbApi.Models;
namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IValidator<Staff> _validator;
    public StaffController(IValidator<Staff> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Staff value)
    {
        ValidationResult results = _validator.Validate(value);

        if (results.IsValid)
        {
            return Ok(value);
        }
        else
        {
            return BadRequest(results.Errors);
        }
    }
}