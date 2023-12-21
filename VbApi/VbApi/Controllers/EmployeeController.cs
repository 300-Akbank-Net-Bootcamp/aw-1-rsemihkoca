using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VbApi.Models;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IValidator<Employee> _validator;

    public EmployeeController(IValidator<Employee> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee value)
    {
        ValidationResult results = _validator.Validate(value);

        if (results.IsValid)
        {
            if (value.DateOfBirth > DateTime.Now.AddYears(-30) && value.HourlySalary < 200)
            {
            }

            return Ok(value);
        }
        else
        {
            return BadRequest(results.Errors);
        }
    }
}