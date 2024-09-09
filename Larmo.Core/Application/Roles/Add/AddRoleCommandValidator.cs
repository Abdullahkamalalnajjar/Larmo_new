using FluentValidation;

namespace Larmo.Core.Application.Roles.Add;

public sealed class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("role name is required");
    }
}