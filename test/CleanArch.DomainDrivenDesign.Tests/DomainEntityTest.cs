// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", "DomainEntity")]
public class DomainEntityTest
{
    [Fact(DisplayName = "Permite atribuição de Id de forma protegida")]
    public void DomainEntity_EnablesProtectedIdAssignment()
    {
        var myMaxIntEntity = new MyIntDomainEntity(true);
        var myMinIntEntity = new MyIntDomainEntity(false);

        Assert.Equal(int.MaxValue, myMaxIntEntity.Id);
        Assert.Equal(int.MinValue, myMinIntEntity.Id);
    }


    #region Stubs
    public class MyIntDomainEntity : DomainEntity<int>
    {
        public MyIntDomainEntity(bool useMax)
        {
            Id = useMax ? int.MaxValue : int.MinValue;
        }
    }
    #endregion
}