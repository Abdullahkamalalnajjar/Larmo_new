using Larmo.Core.Services;
using MediatR;

namespace Larmo.Core.Application.Users.Create;

public sealed class CreateUserCommand : IRequest<AccessTokenResult>
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}