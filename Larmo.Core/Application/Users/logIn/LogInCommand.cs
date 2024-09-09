using Larmo.Core.Services;
using MediatR;

namespace Larmo.Core.Application.Users.logIn;

public sealed class LogInCommand : IRequest<AccessTokenResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
}