// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Enterprise.DomainDrivenDesign;

namespace TheCleanArch.EnterpriseTests;

[Trait("target", "DomainEntity<>")]
public class DomainEntityTest
{
    [Fact(DisplayName = "Deve haver uma fila de eventos vazia ao criar")]
    public void ShouldCreateAnEmptyEventQueue()
    {
        var domainEntity = new MyStubEntity();

        Assert.NotNull(domainEntity);
        Assert.NotNull(domainEntity.GetAllEvents());
        Assert.Empty(domainEntity.GetAllEvents());
    }

    [Fact(DisplayName = "Primeiros eventos devem estar no início da lista")]
    public void FirstEventsMustBeAtTheBeginningOfTheList()
    {
        var domainEntity = new MyStubEntity();
        var domainEvent1 = new DomainEvent();
        var domainEvent2 = new DomainEvent();
        var domainEvent3 = new DomainEvent();

        domainEntity.AddEvent(domainEvent1);
        domainEntity.AddEvent(domainEvent2);
        domainEntity.AddEvent(domainEvent3);

        var allDomainEvents = domainEntity.GetAllEvents().ToArray();

        Assert.NotEmpty(allDomainEvents);
        Assert.Equal(3, allDomainEvents.Length);
        Assert.Equal(domainEvent1.Id, allDomainEvents[0].Id);
        Assert.Equal(domainEvent2.Id, allDomainEvents[1].Id);
        Assert.Equal(domainEvent3.Id, allDomainEvents[2].Id);
    }

    [Fact(DisplayName = "Adicionar um mesmo evento várias vezes não deve replicá-lo")]
    public void AddingTheSameEventMultipleTimesShouldNotReplicateIt()
    {
        var domainEntity = new MyStubEntity();
        var domainEvent1 = new DomainEvent();

        domainEntity.AddEvent(domainEvent1);
        domainEntity.AddEvent(domainEvent1);
        domainEntity.AddEvent(domainEvent1);
        domainEntity.AddEvent(domainEvent1);
        domainEntity.AddEvent(domainEvent1);
        domainEntity.AddEvent(domainEvent1);

        var allDomainEvents = domainEntity.GetAllEvents().ToArray();

        Assert.NotEmpty(allDomainEvents);
        Assert.Single(allDomainEvents);
        Assert.Equal(domainEvent1.Id, allDomainEvents[0].Id);
    }

    [Fact(DisplayName = "Não é possível adicionar um evento nulo")]
    public void CannotAddAaNullDomainEvent()
    {
        var domainEntity = new MyStubEntity();

        var exception = Assert.Throws<ArgumentNullException>(() => domainEntity.AddEvent(null!));

        Assert.Equal("domainEvent", exception.ParamName);
    }

    [Fact(DisplayName = "Um identificador é obrigatório para uma entidade")]
    public void AnIdentifierIsMandatoryForAnEntity()
    {
        int id1 = 1;
        Guid id2 = Guid.NewGuid();

        var eInt = new MyIntEntity(id1);
        var eGuid = new MyGuidEntity(id2);

        Assert.Equal(id1, eInt.Id);
        Assert.Equal(id2, eGuid.Id);
    }

    #region Stubs
    private class MyStubEntity : DomainEntity<int>
    {
        public MyStubEntity() : base(default) { }

        public void AddEvent(DomainEvent domainEvent) => AddDomainEvent(domainEvent);
        public IEnumerable<DomainEvent> GetAllEvents() => GetDomainEvents();
    }

    private class MyIntEntity : DomainEntity<int>
    {
        public MyIntEntity(int id) : base(id) { }
    }
    private class MyGuidEntity : DomainEntity<Guid>
    {
        public MyGuidEntity(Guid id) : base(id) { }
    }
    #endregion
}