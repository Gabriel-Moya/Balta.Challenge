using Balta.Challenge.Core.Contexts.Account.ValueObjects.Exceptions;

namespace Balta.Challenge.Core.Contexts.Account.ValueObjects;

public struct Password
{
    // Constructors
    public Password(string text)
    {
        InvalidPasswordException.ThrowIfIsNullOrEmpty(text);
        InvalidPasswordException.ThrowIfTextLowerThan(text, Configuration.Password.Length);

        HashText(text);
    }

    // Public Properties
    public string Hash { get; private set; } = string.Empty;

    // Private Methods
    // TODO Implement HashText 
    private void HashText(string text)
        => throw new NotImplementedException();

    // Overloads
    public static implicit operator string(Password password)
        => password.Hash;

    public static implicit operator Password(string text)
        => new (text);

    public override readonly string ToString()
        => Hash;
}
