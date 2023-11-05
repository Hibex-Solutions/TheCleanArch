// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core;

using Moq;

namespace CleanArch.DomainDrivenDesign.Tests;

[Trait("target", nameof(DomainEvent))]
public class DomainEventTest
{
    [Fact(DisplayName = "Generate Guid")]
    public void DomainEvent_Generate_Guid()
    {
        var myEvent = new MyDomainEvent();

        Assert.NotEqual(Guid.Empty, myEvent.Id);
    }

    [Theory(DisplayName = "Does not modify Id")]
    [MemberData(nameof(GetConstructorData))]
    public void DomainEvent_DoesNotModify_Id(Guid id)
    {
        var myEvent = new MyDomainEvent(id);

        Assert.Equal(id, myEvent.Id);
    }

    [Fact(DisplayName = "Commited is false on created")]
    public void Commited_IsFalse_OnCreated()
    {
        var myDomainEvent = new MyDomainEvent();

        Assert.False(myDomainEvent.Commited);
    }

    [Fact(DisplayName = "Commited is true if has one handler")]
    public void Commited_IsTrue_IfHasOneHandler()
    {
        var handlerMock = new Mock<ICommandHandler<MyDomainEvent>>();
        var myDomainEvent = new MyDomainEvent();

        myDomainEvent.Commit(handlerMock.Object);

        Assert.True(myDomainEvent.Commited);
    }

    [Fact(DisplayName = "Commited is true if has many handlers")]
    public void Commited_IsTrue_IfHasManyHandlers()
    {
        var handlerMock1 = new Mock<ICommandHandler<MyDomainEvent>>();
        var handlerMock2 = new Mock<ICommandHandler<MyDomainEvent>>();
        var handlerMock3 = new Mock<ICommandHandler<MyDomainEvent>>();
        var myDomainEvent = new MyDomainEvent();

        myDomainEvent.Commit(handlerMock1.Object);
        myDomainEvent.Commit(handlerMock2.Object);
        myDomainEvent.Commit(handlerMock3.Object);

        Assert.True(myDomainEvent.Commited);
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