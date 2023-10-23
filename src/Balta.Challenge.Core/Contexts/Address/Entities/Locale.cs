using Balta.Challenge.Core.Contexts.Address.ValueObjects;

namespace Balta.Challenge.Core.Contexts.Address.Entities;

public class Locale
{
    public Locale() { }
    public Locale(IBGECode id, State state, string city)
    {
        Id = id;
        State = state;
        City = city;
    }

    public int Id { get; set; }
    public State State { get; set; }
    public string City { get; set; }
}
