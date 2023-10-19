using System.Text.RegularExpressions;

namespace Balta.Challenge.Core.Contexts.Account.ValueObjects.Exceptions;

public partial class InvalidEmailException : Exception
{
    // Constants
    private const string DefaultErrorMessage = "Email is not valid";

    [GeneratedRegex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$")]
    private static partial Regex Pattern();

    // Constructors
    public InvalidEmailException() : base(DefaultErrorMessage) { }
    public InvalidEmailException(string? message) : base(message) { }
    public InvalidEmailException(string? message, Exception? innerException) : base(message, innerException) { }

    // Public Methods
    public static void ThrowIfIsInvalid(string? address)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidEmailException();

        address = address.ToLower().Trim();

        if (address.Length < 5)
            throw new InvalidEmailException();

        if (!Pattern().IsMatch(address))
            throw new InvalidEmailException();
    }
}
