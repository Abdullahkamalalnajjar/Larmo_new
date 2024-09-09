namespace Larmo.Core.Application.Users.ViewCollection;

public sealed class GetUsersViewCollectionQueryResult
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedOn { get; set; }
}