// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.


namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", nameof(DomainService))]
public class DomainServiceTests
{
    [Fact(DisplayName = "DomainService must emit events")]
    public void DomainService_MustEmitEvents()
    {
        var domainService = new MyDomainServiceWithTwoEvents();

        Assert.NotNull(domainService);
        Assert.IsAssignableFrom<DomainService>(domainService);
        Assert.NotNull(domainService.EmittedDomainEvents);
        Assert.Equal(2, domainService.EmittedDomainEvents.Count);
    }

    #region Stubs
    public class MyDomainServiceWithTwoEvents : DomainService
    {
        public MyDomainServiceWithTwoEvents()
        {
            var event1 = new MyDomainEvent(new DateTimeOffset(DateTime.Now));
            var event2 = new MyDomainEvent(new DateTimeOffset(DateTime.Now));

            AddDomainEvent(event1);
            AddDomainEvent(event2);
        }
    }

    public class MyDomainEvent : DomainEvent
    {
        public MyDomainEvent(DateTimeOffset createdAt) : base(createdAt)
        {
        }
    }
    #endregion
}