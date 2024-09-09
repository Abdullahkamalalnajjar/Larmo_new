using FluentValidation;

namespace Larmo.Core.Application.Permissions.AssignPermissions;

public sealed class AssignPermissionsToUserCommandValidator : AbstractValidator<AssignPermissionsToUserCommand>
{
    public AssignPermissionsToUserCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .WithMessage("user id is required");

        RuleFor(c => c.PermissionsIds)
            .Must((c, l) => l.Distinct().Count() == c.PermissionsIds.Count)
            .WithMessage("there are duplication permissions ids");
    }
}