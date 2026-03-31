using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public PhoneNumber PhoneNumber { get; private set; } = null!;

    public Patient(string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessRuleException($"El {nameof(name)} es obligatorio");

        Id = Guid.CreateVersion7();
        Name = name;
        Email = new Email(email);
        PhoneNumber = new PhoneNumber(phone); 
    }
}
