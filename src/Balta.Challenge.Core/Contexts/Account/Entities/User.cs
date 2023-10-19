using Balta.Challenge.Core.Contexts.Account.ValueObjects;
using Balta.Challenge.Core.Contexts.Shared.Entities;

namespace Balta.Challenge.Core.Contexts.Account.Entities;

public class User : Entity
{
    // Constructors
    public User(string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    // Public Properties
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
}
