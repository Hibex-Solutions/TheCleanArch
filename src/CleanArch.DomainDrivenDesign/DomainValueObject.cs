// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um objeto de valor no domínio
/// </summary>
public abstract class DomainValueObject
{
    /// <sumary>
    /// Obtém lista de componentes para comparação de igualdade
    /// </sumary>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Utilitário para sobrecarga do operador de igualdade "==" nas classes herdeiras
    /// </summary>
    /// <returns></returns>
    protected static bool EqualOperator(DomainValueObject left, DomainValueObject right)
    {
        return !(left is null ^ right is null)
            && (ReferenceEquals(left, right) || left.Equals(right));
    }

    /// <summary>
    /// Utilitário para sobrecarga do operador de não igualdade "!=" nas classes herdeiras
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    protected static bool NotEqualOperator(DomainValueObject left, DomainValueObject right)
    {
        return !EqualOperator(left, right);
    }

    public override bool Equals(object obj)
    {
        if (obj is not DomainValueObject)
        {
            return false;
        }

        var other = obj as DomainValueObject;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(s => s != null ? s.GetHashCode() : 0)
            .Aggregate((a1, a2) => a1 ^ a2);
    }
}