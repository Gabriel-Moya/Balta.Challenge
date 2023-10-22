namespace Balta.Challenge.Core;

public static class Configuration
{
    public static PasswordConfiguration Password { get; set; } = new();
    public static JwtConfiguration Jwt { get; set; } = new();

    public class PasswordConfiguration
    {
        public int Length { get; set; } = 8;
        public string Salt { get; set; } = string.Empty;
    }

    public class JwtConfiguration
    {
        public string JwtPrivateKey { get; set; } = string.Empty;
    }
}
