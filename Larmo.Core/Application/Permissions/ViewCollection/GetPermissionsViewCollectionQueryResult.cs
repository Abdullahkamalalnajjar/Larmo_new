namespace Larmo.Core.Application.Permissions.ViewCollection;

public sealed class GetPermissionsViewCollectionQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DependOn { get; set; }
    public string ModuleName { get; set; }
}