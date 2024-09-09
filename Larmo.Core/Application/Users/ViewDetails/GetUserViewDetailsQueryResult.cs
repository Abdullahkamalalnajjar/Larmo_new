namespace Larmo.Core.Application.Users.ViewDetails;

public sealed class GetUserViewDetailsQueryResult
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<GetUserPermissionViewDetailsQueryResult> Permissions { get; set; }
}