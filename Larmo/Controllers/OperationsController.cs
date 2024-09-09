using Larmo.Core.Application.Operations;
using Larmo.Core.Application.Operations.Add;
using Larmo.Core.Application.Operations.OperationTypeLookup;
using Larmo.Core.Application.Operations.Update;
using Larmo.Core.Application.Operations.ViewCollection;
using Larmo.Core.Application.Operations.ViewDetails;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Common;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[Authorize(Roles = RoleName.Admin)]
[Route("api/[controller]")]
public class OperationsController : DefaultController
{
    [HttpGet]
    public async Task<ActionResult<PageResponse<OperationResult>>> GetAll([FromQuery] GetOperationCollectionQuery query,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult> AddOperation([FromBody] AddOperationCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet("{operationId:int}")]
    public async Task<ActionResult<OperationResult>> GetById([FromRoute] int operationId, CancellationToken cancellationToken = default)
    {
        var query = new GetOperationDetailsQuery();
        query.SetOperationId(operationId);
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpPut("{operationId:int}")]
    public async Task<ActionResult> UpdateOperation([FromRoute] int operationId, [FromBody] UpdateOperationCommand command,
        CancellationToken cancellationToken = default)
    {
        command.SetOperationId(operationId);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [AllowAnonymous]
    [HttpGet("operation-type-lookup")]
    public async Task<ActionResult<OperationTypeLookupResult[]>> OperationTypeLookup(CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(new OperationTypeLookupQuery(), cancellationToken));
    }
}