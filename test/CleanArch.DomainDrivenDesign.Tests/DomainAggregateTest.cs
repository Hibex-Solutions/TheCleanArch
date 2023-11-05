// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Collections.ObjectModel;

using CleanArch.Core;

using Moq;

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

    [Fact(DisplayName = "TryGetNextNonCommittedDomainEvent fail if GetAllExportedDomainEvents fail")]
    public void TryGetNextNonCommittedDomainEventFail_IfGetAllExportedDomainEventsFail()
    {
        var aggregate = new MyDomainFailAggregate();
        var ex = Assert.Throws<Exception>(() =>
            aggregate.TryGetNextNonCommittedDomainEvent(out DomainEvent domainEvent));

        Assert.NotNull(ex);
        Assert.Equal("GetAllExportedDomainEvents fail!", ex.Message);
    }

    [Fact(DisplayName = "TryGetNextNonCommittedDomainEvent get next event")]
    public void TryGetNextNonCommittedDomainEventFail_GetNextEvent()
    {
        var aggregate = new MyDomainNextEventAggregate();
        var result = aggregate.TryGetNextNonCommittedDomainEvent(out DomainEvent domainEvent);

        Assert.True(result);
        Assert.NotNull(domainEvent);
        Assert.IsType<MyDomainEvent>(domainEvent);
    }

    [Fact(DisplayName = "TryGetNextNonCommittedDomainEvent get next event live")]
    public void TryGetNextNonCommittedDomainEventFail_GetNextEventLive()
    {
        var commandHandlerMock = new Mock<ICommandHandler<MyDomainEvent>>();
        var aggregate = new MyDomainNextEventLiveAggregate();
        var result1 = aggregate.TryGetNextNonCommittedDomainEvent(out DomainEvent domainEvent1);

        aggregate.AddDomainEvent();

        var result2 = aggregate.TryGetNextNonCommittedDomainEvent(out DomainEvent domainEvent2);

        domainEvent2.Commit(commandHandlerMock.Object);

        var result3 = aggregate.TryGetNextNonCommittedDomainEvent(out DomainEvent domainEvent3);

        Assert.False(result1);
        Assert.Null(domainEvent1);

        Assert.True(result2);
        Assert.NotNull(domainEvent2);
        Assert.IsType<MyDomainEvent>(domainEvent2);

        Assert.False(result3);
        Assert.Null(domainEvent3);
    }

    #region Stubs
    public class MyDomainNextEventAggregate : DomainAggregate<MyRootEntity>
    {
        protected override IEnumerable<DomainEvent> GetAllExportedDomainEvents()
        {
            yield return new MyDomainEvent();
        }
    }

    public class MyDomainNextEventLiveAggregate : DomainAggregate<MyRootEntity>
    {
        private List<DomainEvent>? _eventList;

        protected override IEnumerable<DomainEvent>? GetAllExportedDomainEvents()
        => _eventList;

        public void AddDomainEvent()
        {
            (_eventList ??= new()).Add(new MyDomainEvent());
        }
    }

    public class MyDomainFailAggregate : DomainAggregate<MyRootEntity>
    {
        protected override IEnumerable<DomainEvent> GetAllExportedDomainEvents()
        {
            throw new Exception("GetAllExportedDomainEvents fail!");
        }
    }

    public class MyDomainAggregateWithThreeEvents : DomainAggregate<MyRootEntity>
    {
        private readonly List<MyOtherEntity> _others = new();

        public MyDomainAggregateWithThreeEvents()
        {
            RootEntity = new MyRootEntity();
            _others.Add(new MyOtherEntity());
        }

        protected override IEnumerable<DomainEvent> GetAllExportedDomainEvents()
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