using Balta.Challenge.Core.Contexts.Account.ValueObjects.Exceptions;

namespace Balta.Challenge.Core.Contexts.Account.ValueObjects;

public readonly struct Email
{
    // Constructors
    private Email(string address)
    {
        InvalidEmailException.ThrowIfIsInvalid(address);
        Address = address;
    }

    // Public Properties
    public string Address { get; } = null!;

    // Public Methods
    public static Email Create(string address)
        => new (address);

    // Overloads
    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string address)
        => new (address);

    public override string ToString()
        => Address;
}
