using FluentValidation;

namespace Larmo.Core.Application.Notifications.Add;

public sealed class AddNotificationCommandValidator : AbstractValidator<AddNotificationCommand>
{
    public AddNotificationCommandValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty()
            .WithMessage("full name is required");

        RuleFor(c => c.MotherName)
            .NotEmpty()
            .WithMessage("Mother Name is required");

        RuleFor(c => c.NearestMilestone)
            .NotEmpty()
            .WithMessage("Nearest Milestone is required");

        RuleFor(c => c.Street)
            .NotEmpty()
            .WithMessage("Street is required");

        RuleFor(c => c.Area)
            .NotEmpty()
            .WithMessage("Area is required");

        RuleFor(c => c.City)
            .NotEmpty()
            .WithMessage("City is required");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("City is required");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber is required");

        RuleFor(c => c.PassportNumber)
            .NotEmpty()
            .WithMessage("Passport Number is required");

        RuleFor(c => c.Nationality)
            .NotEmpty()
            .WithMessage("Nationality is required")
            .When(c => !c.IsLibyanNationality);

        RuleFor(c => c.IdentityNumber)
            .NotEmpty()
            .WithMessage("Identity Number is required");

        RuleFor(c => c.Employer)
            .NotEmpty()
            .WithMessage("Employer is required");

        RuleFor(c => c.Profession)
            .NotEmpty()
            .WithMessage("Profession is required");

        RuleFor(c => c.PassportNumberIssueDate)
            .NotEmpty()
            .WithMessage("Passport Number Issue Date is required");

        RuleFor(c => c.PassportNumberExpiryDate)
            .NotEmpty()
            .WithMessage("Passport Number Expiry Date is required");

        RuleFor(c => c.IdentityIssueDate)
            .NotEmpty()
            .WithMessage("Identity Issue Date is required");

        RuleFor(c => c.IdentityExpiryDate)
            .NotEmpty()
            .WithMessage("Identity Expiry Date is required");

        RuleFor(c => c.Gender)
            .IsInEnum()
            .WithMessage("Gender is required");

        RuleFor(c => c.MaritalStatus)
            .IsInEnum()
            .WithMessage("Marital Status is required");

        RuleFor(c => c.StartWorkDate)
            .NotEmpty()
            .WithMessage("Star tWork Date is required");
    }
}