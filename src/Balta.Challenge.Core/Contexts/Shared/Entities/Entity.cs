namespace Balta.Challenge.Core.Contexts.Shared.Entities;

public class Entity
{
    protected Entity()
        => Id = Guid.NewGuid();

    public Guid Id { get; }
}
