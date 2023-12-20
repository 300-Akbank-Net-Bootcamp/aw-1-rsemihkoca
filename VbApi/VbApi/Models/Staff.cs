using System.ComponentModel.DataAnnotations;
namespace VbApi.Models;

public class Staff
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? HourlySalary { get; set; }
}