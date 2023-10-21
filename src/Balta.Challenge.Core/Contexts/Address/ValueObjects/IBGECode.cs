using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balta.Challenge.Core.Contexts.Address.ValueObjects.Exceptions;

namespace Balta.Challenge.Core.Contexts.Address.ValueObjects;
public readonly struct IBGECode
{
    // Constructors
    private IBGECode(int value)
    {
        InvalidIBGEException.ThrowIfIsInvalid(value);
        Value = value;
    }

    public int Value { get; } = null!;

    public static IBGECode Create(int value)
       => new(value);
}
