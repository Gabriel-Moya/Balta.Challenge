using Balta.Challenge.Core.Contexts.Address.ValueObjects;
using Balta.Challenge.Core.Contexts.Shared.Entities;

namespace Balta.Challenge.Core.Contexts.Address.Entities;
public class Locale : Entity
{
    public Locale() { }
    public Locale(IBGECode ibgeCode, State state, string city)
    {
        IBGECode = ibgeCode;
        State = state;
        City = city;
    }

    public IBGECode IBGECode { get; set; }
    public State State { get; set; }
    public string City { get; set; }
}
