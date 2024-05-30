// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Enterprise.DomainDrivenDesign;

namespace TheCleanArch.EnterpriseTests;

[Trait("target", nameof(DomainEvent))]
public class DomainEventTest
{
    [Fact(DisplayName = "DomainEvent gera um novo Guid quando criado")]
    public void GenerateNewGuidOnCreate()
    {
        var domainEvent = new DomainEvent();

        Assert.NotNull(domainEvent);
        Assert.IsType<Guid>(domainEvent.Id);
    }

    [Fact(DisplayName = "DomainEvent preserva o Guid informado quando criado")]
    public void PreserveGuidOnCreate()
    {
        Guid domainGuidId = Guid.NewGuid();
        var domainEvent = new DomainEvent(domainGuidId);

        Assert.NotNull(domainEvent);
        Assert.Equal(domainGuidId, domainEvent.Id);
    }
}