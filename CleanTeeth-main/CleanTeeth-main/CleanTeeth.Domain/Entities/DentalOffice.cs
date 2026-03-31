using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class DentalOffice
{
    public Guid Id { get;private set; }
    public string Name { get; private set; } = null!;
    public Address Address { get; private set; }

    public DentalOffice(string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleException($"El {nameof(name)} es obligatorio");
        }

        Name = name;
        Address = address;
        Id = Guid.CreateVersion7();        
    }
}
