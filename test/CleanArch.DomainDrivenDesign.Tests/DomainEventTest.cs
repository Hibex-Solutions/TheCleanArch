// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", nameof(DomainEvent))]
public class DomainEventTest
{
    [Fact]
    public void DomainEvent_Generate_Guid()
    {
        var myEvent = new MyDomainEvent();

        Assert.NotEqual(Guid.Empty, myEvent.Id);
    }

    [Theory]
    [InlineData(nameof(GetConstructorData))]
    public void DomainEvent_DoesNotModify_Id(Guid id)
    {
        var myEvent = new MyDomainEvent(id);

        Assert.Equal(id, myEvent.Id);
    }

    #region Data generators
    public static IEnumerable<object[]> GetConstructorData()
    {
        yield return new object[] { Guid.NewGuid() };
        yield return new object[] { Guid.NewGuid() };
        yield return new object[] { Guid.NewGuid() };
    }
    #endregion

    #region Stubs
    public class MyDomainEvent : DomainEvent
    {
        public MyDomainEvent() : base() { }

        public MyDomainEvent(Guid id) : base(id) { }
    }
    #endregion
}