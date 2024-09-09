namespace Larmo.Core.Services;

public sealed record AccessTokenResult
{
    public string AccessToken { get; set; }
    public DateTime ExpireOn { get; set; }
    public RefreshTokenResult RefreshToken { get; set; }
}