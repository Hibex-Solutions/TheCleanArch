// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Collections;
using System.Linq;
using System.Threading.Tasks;

using CleanArch.Core.Patterns.CommandHandler;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

using Moq;

namespace CleanArch.Core.Tests.Patterns.CommandHandler;

[Trait("target", nameof(DefaultCommandHandlerDiscoverer))]
public class DefaultCommandHandlerDiscovererTest
{
    [Fact(DisplayName = "Must return empty list when type has no registered handler")]
    public void MustReturnEmptyList_WhenTypeHasNoRegisteredHandler()
    {
        var collection = new ServiceCollection();
        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var discoverer = new DefaultCommandHandlerDiscoverer(serviceProvider);

        var handlers = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));

        Assert.NotNull(handlers);
        Assert.Empty(handlers);
    }

    [Fact(DisplayName = "An exception should be raised when the specified type does not implement ICommand")]
    public void AnExceptionShouldBeRaised_WhenTheSpecifiedTypeDoesNotImplementICommand()
    {
        var serviceProviderMock = new Mock<IServiceProvider>();
        var discoverer = new DefaultCommandHandlerDiscoverer(serviceProviderMock.Object);

        var ex = Assert.Throws<InvalidCastException>(() =>
            discoverer.GetCommandHandlersByCommandType(typeof(CommandThatDoesNotImplementICommand)));

        Assert.NotNull(ex);
        Assert.Equal("The command type must be implements ICommand interface", ex.Message);
    }

    [Fact(DisplayName = "Returns only handlers of the requested type")]
    public void GetCommandHandlersByCommandType_ReturnsOnlyHandlersOfTheRequestedType()
    {
        var collection = new ServiceCollection();

        collection.AddScoped<ICommandHandler, CommandHandler1Of2>();
        collection.AddScoped<ICommandHandler, CommandHandler2Of2>();
        collection.AddScoped<ICommandHandler, MyCommandHandler>();

        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var discoverer = new DefaultCommandHandlerDiscoverer(serviceProvider);

        var handlers = discoverer.GetCommandHandlersByCommandType(typeof(CommandWithTwoHandlers));
        var handlersTypes = handlers.Select(h => h.GetType());

        Assert.NotNull(handlers);
        Assert.NotEmpty(handlers);
        Assert.Equal(2, handlers.Count());
        Assert.Contains(typeof(CommandHandler1Of2), handlersTypes);
        Assert.Contains(typeof(CommandHandler1Of2), handlersTypes);
    }

    [Fact(DisplayName = "Always tries to get IMemoryCache service when it is not configured")]
    public void GetCommandHandlersByCommandType_AlwaysTriesToGetIMemoryCacheService_WhenItIsNotConfigured()
    {
        var serviceProviderMock = new Mock<IServiceProvider>();
        var discoverer = new DefaultCommandHandlerDiscoverer(serviceProviderMock.Object);

        _ = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));

        serviceProviderMock.Verify(v => v.GetService(typeof(IMemoryCache)), Times.Exactly(2));
    }

    [Fact(DisplayName = "Attempts to get IMemoryCache service only once when configured")]
    public void GetCommandHandlersByCommandType_AttemptsToGetIMemoryCacheServiceOnlyOnce_WhenConfigured()
    {
        var memoryCacheMock = new Mock<IMemoryCache>();
        var serviceProviderMock = new Mock<IServiceProvider>();

        serviceProviderMock.Setup(s => s.GetService(typeof(IMemoryCache)))
            .Returns(memoryCacheMock.Object);

        var discoverer = new DefaultCommandHandlerDiscoverer(serviceProviderMock.Object);

        _ = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));
        _ = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));
        _ = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));
        _ = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));
        _ = discoverer.GetCommandHandlersByCommandType(typeof(MyCommand));

        serviceProviderMock.Verify(v => v.GetService(typeof(IMemoryCache)), Times.Exactly(1));
    }

    #region Stubs
    public class MyCommand : ICommand { }
    public class CommandWithTwoHandlers : ICommand { }
    public class CommandThatDoesNotImplementICommand { }

    public class CommandHandler1Of2 : CommandHandler<CommandWithTwoHandlers>
    {
        protected override Task HandleAsync(CommandWithTwoHandlers command)
        {
            throw new NotImplementedException();
        }
    }

    public class CommandHandler2Of2 : CommandHandler<CommandWithTwoHandlers>
    {
        protected override Task HandleAsync(CommandWithTwoHandlers command)
        {
            throw new NotImplementedException();
        }
    }

    public class MyCommandHandler : CommandHandler<MyCommand>
    {
        protected override Task HandleAsync(MyCommand command)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}