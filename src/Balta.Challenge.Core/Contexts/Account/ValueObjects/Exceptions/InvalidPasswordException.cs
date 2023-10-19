namespace Balta.Challenge.Core.Contexts.Account.ValueObjects.Exceptions;

public class InvalidPasswordException : Exception
{
    // Constants
    private const string DefaultErrorMessage = "Invalid or insecure password";

    // Constructos
    public InvalidPasswordException() : base(DefaultErrorMessage) { }

    public InvalidPasswordException(string? message) : base(message) { }

    public InvalidPasswordException(
        string? message,
        Exception? innerException) : base(message, innerException) { }

    // Public Methods
    public static void ThrowIfIsNullOrEmpty(string text, string errorMessage = "The password must be provided")
    {
        if (string.IsNullOrEmpty(text))
            throw new InvalidPasswordException(errorMessage);
    }

    public static void ThrowIfTextLowerThan(string text, int length, string errorMessage = "Password too short")
    {
        if (text.Length < length)
            throw new InvalidPasswordException(errorMessage);
    }
}
