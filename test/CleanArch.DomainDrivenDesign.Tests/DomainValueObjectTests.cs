// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", nameof(DomainValueObject))]
public class DomainValueObjectTests
{
    [Fact(DisplayName = "DomainValueObject are comparable")]
    public void DomainValueObject_AreComparable()
    {
        var value1 = new MyDomainValueObject(1, "One");
        var value2 = new MyDomainValueObject(1, "One");
        var value3 = new MyDomainValueObject(3, "Three");

        Assert.Equal(value1, value2);
        Assert.NotEqual(value1, value3);
        Assert.NotEqual(value2, value3);

        Assert.True(value1 == value2);
        Assert.True(value1.Equals(value2));

        Assert.True(value1 != value3);
        Assert.False(value1.Equals(value3));
    }

    [Fact(DisplayName = "HashCode are comparable")]
    public void DomainValueObjectHashCode_AreComparable()
    {
        var value1 = new MyDomainValueObject(2, "Two");
        var value2 = new MyDomainValueObject(2, "Two");
        var value3 = new MyDomainValueObject(3, "Tree");

        Assert.Equal(value1.GetHashCode(), value2.GetHashCode());
        Assert.NotEqual(value2.GetHashCode(), value3.GetHashCode());
    }

    [Fact(DisplayName = "Iis not compatible with other types")]
    public void DomainValueObject_IsNotCompatibleWithOtherTypes()
    {
        var value1 = new MyDomainValueObject(1, "One");
        var value2 = new Object();

        Assert.False(value1.Equals(value2));
    }

    #region Stubs
    private class MyDomainValueObject : DomainValueObject
    {
        public MyDomainValueObject(int a, string b)
        {
            IntegerValue = a;
            StringValue = b;
        }

        public int IntegerValue { get; private set; }
        public string StringValue { get; private set; }

        public static bool operator ==(MyDomainValueObject one, MyDomainValueObject two) => EqualOperator(one, two);

        public static bool operator !=(MyDomainValueObject one, MyDomainValueObject two) => NotEqualOperator(one, two);

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Obtém uma lista de componentes para comparação de igualdade
        /// </summary>
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return IntegerValue;
            yield return StringValue;
        }
    }
    #endregion
}