// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", "DomainAggregate")]
public class DomainAggregateTests
{
    [Fact(DisplayName = "DomainAggregate must emit events")]
    public void DomainAggregate_MustEmitEvents()
    {
        var domainAggregate = new MyDomainAggregateWithThreeEvents();

        Assert.NotNull(domainAggregate);
        Assert.IsAssignableFrom<DomainAggregate<MyRootEntity>>(domainAggregate);
        Assert.NotNull(domainAggregate.EmittedDomainEvents);
        Assert.Equal(3, domainAggregate.EmittedDomainEvents.Count);
    }

    #region Stubs
    public class MyDomainAggregateWithThreeEvents : DomainAggregate<MyRootEntity>
    {
        public MyDomainAggregateWithThreeEvents()
        {
            var event1 = new MyDomainEvent(new DateTimeOffset(DateTime.Now));
            var event2 = new MyDomainEvent(new DateTimeOffset(DateTime.Now));
            var event3 = new MyDomainEvent(new DateTimeOffset(DateTime.Now));

            AddDomainEvent(event1);
            AddDomainEvent(event2);
            AddDomainEvent(event3);
        }
    }

    public class MyRootEntity : DomainEntity<int>, IDomainAggregateRoot { }

    public class MyDomainEvent : DomainEvent
    {
        public MyDomainEvent(DateTimeOffset createdAt) : base(createdAt)
        { }
    }
    #endregion
}