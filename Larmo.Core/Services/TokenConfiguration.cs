namespace Larmo.Core.Services;

public class TokenConfiguration
{
    public const string TokenSection = "JWT";

    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public string Secret { get; set; }
    public int AccessTokenLifeTimeInMinutes { get; set; }
    public int RefreshTokenLifeTimeInMinutes { get; set; }
}