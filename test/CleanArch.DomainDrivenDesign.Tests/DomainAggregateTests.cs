// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Collections.ObjectModel;

using CleanArch.Core;

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", "DomainAggregate")]
public class DomainAggregateTests
{
    [Fact(DisplayName = "DomainAggregate must emit events")]
    public void DomainAggregate_MustEmitEvents()
    {
        var domainAggregate = new MyDomainAggregateWithThreeEvents();
        var firstEvents = domainAggregate.GetDomainEvents();

        domainAggregate.EmitOtherEvent();

        var lastEvents = domainAggregate.GetDomainEvents();

        Assert.NotNull(domainAggregate);
        Assert.IsAssignableFrom<DomainAggregate<MyRootEntity>>(domainAggregate);
        Assert.NotNull(domainAggregate.RootEntity);
        Assert.Equal(2, firstEvents.Count);
        Assert.Equal(3, lastEvents.Count);
    }

    #region Stubs
    public class MyDomainAggregateWithThreeEvents : DomainAggregate<MyRootEntity>
    {
        private readonly List<MyOtherEntity> _others = new();

        public MyDomainAggregateWithThreeEvents()
        {
            RootEntity = new MyRootEntity();
            _others.Add(new MyOtherEntity());
        }

        public override IAsyncEnumerable<IHandleableCustomEvent> CollectEmittedCustomEvents()
        {
            throw new NotImplementedException();
        }

        public void EmitOtherEvent() => _others?.FirstOrDefault()?.Method();

        public ReadOnlyCollection<DomainEvent> GetDomainEvents()
        {
            var allEvents = new List<DomainEvent>();

            allEvents.AddRange(RootEntity.ExportedDomainEvents);

            _others.ForEach(o => allEvents.AddRange(o.ExportedDomainEvents));

            return allEvents.AsReadOnly();
        }
    }

    public class MyRootEntity : DomainEntity<int>
    {
        public MyRootEntity()
        {
            DomainEvents.Add(new MyDomainEvent(DateTimeOffset.UtcNow));
            DomainEvents.Add(new MyDomainEvent(DateTimeOffset.UtcNow));
        }
    }

    public class MyOtherEntity : DomainEntity<int>
    {
        public void Method()
        {
            DomainEvents.Add(new MyDomainEvent(DateTimeOffset.UtcNow));
        }
    }

    public class MyDomainEvent : DomainEvent
    {
        public MyDomainEvent(DateTimeOffset createdAt) : base(createdAt)
        { }
    }
    #endregion
}