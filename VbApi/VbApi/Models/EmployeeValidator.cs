using FluentValidation;

namespace VbApi.Models;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(10, 250)
            .WithMessage("Invalid Name");

        RuleFor(employee => employee.DateOfBirth)
            .NotEmpty()
            .Must(dateOfBirth => DateTime.Today.AddYears(-65) <= dateOfBirth)
            .WithMessage("Birthdate is not valid.");
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email address is not valid.");
            
        RuleFor(x => x.Phone)
            .Matches(@"^((?:[0-9]\-?){6,14}[0-9])|((?:[0-9]\x20?){6,14}[0-9])$")
            .WithMessage("Phone is not valid.");

        RuleFor(employee => employee.HourlySalary)
            .InclusiveBetween(50, 400).WithMessage("Hourly salary does not fall within allowed range.")
            .Must(IsValidHourlySalary)
            .WithMessage("Minimum hourly salary is not valid.");
    }
    
    private static bool IsValidHourlySalary(Employee employee, double hourlySalary)
    {
        var dateBeforeThirtyYears = DateTime.Today.AddYears(-30);
        var isOlderThanThirdyYears = employee.DateOfBirth <= dateBeforeThirtyYears;
        return isOlderThanThirdyYears ? hourlySalary >= 200 : hourlySalary >= 50;
    }
}