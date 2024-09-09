namespace Larmo.Core.Services;

public sealed record RefreshTokenResult
{
    public string UserId { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpireOn { get; set; }
}