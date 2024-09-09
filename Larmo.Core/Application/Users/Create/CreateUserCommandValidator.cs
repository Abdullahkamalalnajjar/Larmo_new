using FluentValidation;
using Larmo.Shared.Extension;

namespace Larmo.Core.Application.Users.Create;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("phone number is required");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("email is required");

        RuleFor(c => c.Username)
            .NotEmpty()
            .WithMessage("username is required");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("password is required")
            .IsEnglish(allowSpaces: false, allowNumbers: true);
    }
}