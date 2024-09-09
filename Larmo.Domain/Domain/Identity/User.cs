using Microsoft.AspNetCore.Identity;

namespace Larmo.Domain.Domain.Identity;

public class User : IdentityUser<string>
{
    private readonly List<UserPermission> _userPermissions = [];

    private User()
    {
    }

    public RefreshToken RefreshToken { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime? ModifiedOn { get; private set; }
    public IReadOnlyCollection<UserPermission> UserPermissions => _userPermissions;

    public static User Create(string email, string userName, string phoneNumber)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString("N"),
            PhoneNumber = phoneNumber,
            Email = email,
            NormalizedEmail = email.ToUpper(),
            UserName = userName,
            CreatedOn = DateTime.UtcNow
        };

        return user;
    }

    public void SetRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public void AddToPermission(Permission permission)
    {
        var userPermission = UserPermission.Create(Id, permission.Id);
        _userPermissions.Add(userPermission);
    }

    public void ClearPermission()
    {
        _userPermissions.Clear();
    }
}