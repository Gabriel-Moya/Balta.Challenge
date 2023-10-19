namespace Balta.Challenge.Core;

public static class Configuration
{
    public static PasswordConfiguration Password { get; set; } = new();

    public class PasswordConfiguration
    {
        public int Length { get; } = 8;
        public string Salt { get; } = string.Empty;
    }
}
