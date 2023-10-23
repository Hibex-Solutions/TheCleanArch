// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.DomainDrivenDesign;

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", nameof(DomainEvent))]
public class DomainEventTests
{
    [Fact]
    public void DomainEvent_Generate_Guid()
    {
        var nowOffset = new DateTimeOffset(DateTime.Now);
        var myEvent = new MyDomainEvent(nowOffset);

        Assert.Equal(nowOffset, myEvent.CreatedAt);
        Assert.NotEqual(Guid.Empty, myEvent.Id);
    }

    [Theory]
    [MemberData(nameof(GetConstructorData))]
    public void DomainEvent_DoesNotModify_IdAndCreatedAt(Guid id, DateTime createdAt)
    {
        var myEvent = new MyDomainEvent(id, new DateTimeOffset(createdAt));

        Assert.Equal(id, myEvent.Id);
        Assert.Equal(new DateTimeOffset(createdAt), myEvent.CreatedAt);
    }

    #region Data generators
    public static IEnumerable<object[]> GetConstructorData()
    {
        yield return new object[] { Guid.NewGuid(), new DateTime(2023, 10, 23, 9, 52, 15) };
        yield return new object[] { Guid.NewGuid(), new DateTime(1983, 8, 8) };
        yield return new object[] { Guid.NewGuid(), new DateTime(1969, 7, 20, 23, 56, 0) };
    }
    #endregion

    #region Stubs
    public class MyDomainEvent : DomainEvent
    {
        public MyDomainEvent(DateTimeOffset createdAt) : base(createdAt)
        {
        }

        public MyDomainEvent(Guid id, DateTimeOffset createdAt) : base(id, createdAt)
        {
        }
    }
    #endregion
}