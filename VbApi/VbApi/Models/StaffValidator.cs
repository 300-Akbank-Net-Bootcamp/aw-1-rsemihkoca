using FluentValidation;

namespace VbApi.Models;

public class StaffValidator : AbstractValidator<Staff>
{
    public StaffValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(10, 250)
            .WithMessage("Name must be between 10 and 250 characters.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email address is not valid.");

        RuleFor(x => x.Phone)
            .Matches(@"^((?:[0-9]\-?){6,14}[0-9])|((?:[0-9]\x20?){6,14}[0-9])$")
            .WithMessage("Phone is not valid.");

        RuleFor(x => x.HourlySalary)
            .InclusiveBetween(30, 400)
            .WithMessage("Hourly salary does not fall within allowed range.");
    }
}