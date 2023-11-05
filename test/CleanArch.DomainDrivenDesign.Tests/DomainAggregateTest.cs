// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Collections.ObjectModel;

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", "DomainAggregate")]
public class DomainAggregateTest
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

        public override IEnumerable<DomainEvent> GetAllExportedDomainEvents()
        {
            throw new NotImplementedException();
        }

        public void EmitOtherEvent() => _others?.FirstOrDefault()?.Method();

        public ReadOnlyCollection<DomainEvent> GetDomainEvents()
        {
            var allEvents = new List<DomainEvent>();

            allEvents.AddRange(RootEntity.GetExportedDomainEvents());

            _others.ForEach(o => allEvents.AddRange(o.GetExportedDomainEvents()));

            return allEvents.AsReadOnly();
        }
    }

    public class MyRootEntity : DomainEntity<int>
    {
        public MyRootEntity()
        {
            var events = GetDomainEventList();

            events.Add(new MyDomainEvent());
            events.Add(new MyDomainEvent());
        }
    }

    public class MyOtherEntity : DomainEntity<int>
    {
        public void Method()
        {
            GetDomainEventList().Add(new MyDomainEvent());
        }
    }

    public class MyDomainEvent : DomainEvent { }
    #endregion
}