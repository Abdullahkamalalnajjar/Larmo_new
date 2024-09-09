using MediatR;

namespace Larmo.Core.Application.Roles.Add;

public class AddRoleCommand : IRequest
{
    public string Name { get; set; }
}