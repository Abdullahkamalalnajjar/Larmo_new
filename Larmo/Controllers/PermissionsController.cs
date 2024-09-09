using Larmo.Core.Application.Permissions.AssignPermissions;
using Larmo.Core.Application.Permissions.ViewCollection;
using Larmo.Shared.Common;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[Authorize(Roles = RoleName.Admin)]
[Route("api/[controller]")]
public class PermissionsController : DefaultController
{
    [HttpGet]
    public async Task<ActionResult<List<GetPermissionsViewCollectionQueryResult>>> GetAll(CancellationToken cancellationToken = default)
    {
        var query = new GetPermissionsViewCollectionQuery();
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpPut]
    public async Task<ActionResult<List<GetPermissionsViewCollectionQueryResult>>> AssignPermissionToUser(
        [FromBody] AssignPermissionsToUserCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }
}