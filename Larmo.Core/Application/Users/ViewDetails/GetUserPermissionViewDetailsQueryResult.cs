namespace Larmo.Core.Application.Users.ViewDetails;

public sealed class GetUserPermissionViewDetailsQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DependOn { get; set; }
    public string ModuleName { get; set; }
}