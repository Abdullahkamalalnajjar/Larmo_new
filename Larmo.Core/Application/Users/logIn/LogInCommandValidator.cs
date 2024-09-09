using FluentValidation;
using Larmo.Shared.Extension;

namespace Larmo.Core.Application.Users.logIn;

public sealed class LogInCommandValidator : AbstractValidator<LogInCommand>
{
    public LogInCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("email is required");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("password is required")
            .IsEnglish(allowSpaces: false, allowNumbers: true);
    }
}