namespace Larmo.Domain.Domain.Identity;

public class RefreshToken
{
    private RefreshToken()
    {
    }

    public string Id { get; set; }
    public string UserId { get; set; }
    public string Value { get; set; }
    public DateTime ExpireOn { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    public static RefreshToken Create(string value, DateTime expireOn)
    {
        var user = new RefreshToken
        {
            Id = Guid.NewGuid().ToString("N"),
            Value = value,
            CreatedOn = DateTime.UtcNow,
            ExpireOn = expireOn
        };

        return user;
    }
}