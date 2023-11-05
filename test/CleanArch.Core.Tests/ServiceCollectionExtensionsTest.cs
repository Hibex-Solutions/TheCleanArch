// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Core.Tests;

[Trait("target", nameof(ServiceCollectionExtensions))]
public class ServiceCollectionExtensionsTest
{
    [Fact(DisplayName = "DefaultTimeProvider is registered with AddCleanArchDefaults()")]
    public void DefaultTimeProviderIsRegistered_WithAddCleanArchDefaults()
    {
        var collection = new ServiceCollection().AddCleanArchDefaults();
        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var instance = serviceProvider.GetService<ITimeProvider>();

        Assert.NotNull(instance);
        Assert.IsType<DefaultTimeProvider>(instance);
    }

    [Fact(DisplayName = "Test")]
    public void Test()
    {
        var thisAssembly = typeof(MyCommand).Assembly;
        var collection = new ServiceCollection().AddCleanArchCommandHandlersFromAssembly(thisAssembly);
        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);

        var commandHandlerGenericType = typeof(ICommandHandler<>);

        var instance = serviceProvider.GetService(commandHandlerGenericType);
    }

    #region Stubs
    public class MyCommand : ICommand { }

    public class MyMockCommandHandler1 : ICommandHandler<MyCommand>
    {
        public Task HandleAsync(MyCommand command) => throw new NotImplementedException();
    }

    public class MyMockCommandHandler2 : ICommandHandler<MyCommand>
    {
        public Task HandleAsync(MyCommand command) => throw new NotImplementedException();
    }

    public class MyMockCommandHandler3 : ICommandHandler<MyCommand>
    {
        public Task HandleAsync(MyCommand command) => throw new NotImplementedException();
    }
    #endregion
}