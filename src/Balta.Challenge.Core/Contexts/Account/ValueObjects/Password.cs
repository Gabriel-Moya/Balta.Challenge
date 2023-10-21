using Balta.Challenge.Core.Contexts.Account.ValueObjects.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace Balta.Challenge.Core.Contexts.Account.ValueObjects;

public struct Password
{
    // Constructors
    private Password(string text)
    {
        InvalidPasswordException.ThrowIfIsNullOrEmpty(text);
        InvalidPasswordException.ThrowIfTextLowerThan(text, Configuration.Password.Length);

        Hash = HashText(text);
    }

    // Public Properties
    public string Hash { get; private set; } = string.Empty;

    // Public Methods
    public static Password Create(string text)
        => new (text);

    public bool PasswordIsValid(string text)
        => HashText(text) == Hash;

    // Private Methods
    private static string HashText(string text)
    {
        text += Configuration.Password.Salt;

        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            var builder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    // Overloads
    public static implicit operator string(Password password)
        => password.Hash;

    public static implicit operator Password(string text)
        => new (text);

    public override readonly string ToString()
        => Hash;
}
