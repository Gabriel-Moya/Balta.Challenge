using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.Challenge.Core.Contexts.Address.ValueObjects.Exceptions;
public partial class InvalidIBGEException : Exception
{
    private const string DefaultErrorMessage = "IBGE code is not valid";

    public InvalidIBGEException() : base(DefaultErrorMessage) { }
    public InvalidIBGEException(string? message) : base(message) { }

    public static void ThrowIfIsInvalid(int code)
    {
        if (code.ToString().Length != 7)
            throw new InvalidIBGEException("The length of ibge code must be equal to 7");
    }
}

