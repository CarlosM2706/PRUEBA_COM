using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanTeeth.Domain.ValueObjects;

public sealed record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new BusinessRuleException("El teléfono es requerido");
        if (value.Length < 10) throw new BusinessRuleException("Debe tener al menos 10 dígitos");
        if (!Regex.IsMatch(value, @"^[0-9+\-\(\)\s]+$"))
            throw new BusinessRuleException("El teléfono contiene caracteres inválidos");
        Value = value;
    }
}
