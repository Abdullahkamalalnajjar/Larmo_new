using Larmo.Core.Application.Roles.Add;
using Larmo.Core.Application.Roles.AddAdmin;
using Larmo.Shared.Common;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[Authorize(Roles = RoleName.Admin)]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("api/[controller]")]
public class RolesController : DefaultController
{
    [AllowAnonymous]
    [HttpPost("admin")]
    public async Task<ActionResult> Add(CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new AddAdminRoleCommand(), cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddRoleCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}