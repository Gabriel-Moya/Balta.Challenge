using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.Challenge.Core.Contexts.Address.ValueObjects.Exceptions;
public partial class InvalidStateException : Exception
{
    private const string DefaultErrorMessage = "State is not valid";

    public InvalidStateException() : base(DefaultErrorMessage) { }
    public InvalidStateException(string? message) : base(message) { }

    public static void ThrowIfIsInvalid(string? state)
    {
        if (string.IsNullOrEmpty(state))
            throw new InvalidStateException();

        state = state.ToLower().Trim();

        if (state.Length != 2)
            throw new InvalidStateException("The length of state must be equal to 2");

    }

}
