using Balta.Challenge.Core.Contexts.Address.ValueObjects.Exceptions;

namespace Balta.Challenge.Core.Contexts.Address.ValueObjects;
public class IBGECode
{
    // Constructors
    protected IBGECode() { }
    private IBGECode(int value)
    {
        InvalidIBGEException.ThrowIfIsInvalid(value);
        Value = value;
    }

    public int Value { get; }

    public static IBGECode Create(int value)
       => new(value);

    public static implicit operator int(IBGECode ibgeCode)
     => ibgeCode.Value;
}
