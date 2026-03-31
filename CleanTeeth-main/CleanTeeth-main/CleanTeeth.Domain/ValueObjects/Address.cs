using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Domain.ValueObjects;

public sealed record Address(string Street, string City, string ZipCode)
{
    public static Address Create(string street, string city, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city))
            throw new BusinessRuleException("Todos los campos son requeridos");
        if (zipCode.Length != 5)
            throw new BusinessRuleException("El ZipCode debe tener exactamente 5 dígitos");

        return new Address(street, city, zipCode);
    }
}



