using Larmo.Core.Application.Users.Create;
using Larmo.Core.Application.Users.CreateAdmin;
using Larmo.Core.Application.Users.logIn;
using Larmo.Core.Application.Users.ViewCollection;
using Larmo.Core.Application.Users.ViewDetails;
using Larmo.Core.Services;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Common;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[Authorize(Roles = RoleName.Admin)]
[Route("api/[controller]")]
public class UsersController : DefaultController
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost("admin")]
    public async Task<ActionResult> CreateAdmin(CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new CreateAdminCommand(), cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<AccessTokenResult>> Add([FromBody] CreateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AccessTokenResult>> LogIn([FromBody] LogInCommand command,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<PageResponse<GetUsersViewCollectionQueryResult>>> ViewCollection(
        [FromQuery] GetUsersViewCollectionQuery query, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<GetUserViewDetailsQueryResult>> ViewCollection(
        [FromRoute] string userId, CancellationToken cancellationToken = default)
    {
        var query = new GetUserViewDetailsQuery(userId);
        return Ok(await Mediator.Send(query, cancellationToken));
    }
}