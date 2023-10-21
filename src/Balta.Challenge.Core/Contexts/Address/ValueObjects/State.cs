using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balta.Challenge.Core.Contexts.Address.ValueObjects.Exceptions;

namespace Balta.Challenge.Core.Contexts.Address.ValueObjects;
public readonly struct State
{
    // Constructors
    private State(string value)
    {
        InvalidStateException.ThrowIfIsInvalid(value);
        Value = value;
    }

    public string Value { get; } = null!;

    public static State Create(string value)
       => new(value);
}
