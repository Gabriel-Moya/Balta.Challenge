using Balta.Challenge.Core.Contexts.Address.ValueObjects.Exceptions;

namespace Balta.Challenge.Core.Contexts.Address.ValueObjects;
public class State
{
    // Constructors
    protected State() { }
    private State(string value)
    {
        InvalidStateException.ThrowIfIsInvalid(value);
        Value = value;
    }

    public string Value { get; } = null!;

    public static State Create(string value)
       => new(value);
}
