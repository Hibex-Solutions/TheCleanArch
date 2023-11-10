// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Linq;
using System.Threading.Tasks;

using CleanArch.Core.Patterns.CommandHandler;

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

    [Fact(DisplayName = "DefaultCommandHandlerDiscoverer is registered with AddCleanArchDefaults()")]
    public void DefaultCommandHandlerDiscoverer_WithAddCleanArchDefaults()
    {
        var collection = new ServiceCollection().AddCleanArchDefaults();
        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var instance = serviceProvider.GetService<ICommandHandlerDiscoverer>();

        Assert.NotNull(instance);
        Assert.IsType<DefaultCommandHandlerDiscoverer>(instance);
    }

    [Fact(DisplayName = "AddCleanArchCommandHandlersFromAssembly() registers all ICommandHandlers")]
    public void AddCleanArchCommandHandlersFromAssembly_RegistersAllICommandHandlers()
    {
        var thisAssembly = typeof(MyCommand).Assembly;
        var collection = new ServiceCollection().AddCleanArchCommandHandlersFromAssembly(thisAssembly);
        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);

        var instances = serviceProvider.GetServices<ICommandHandler>();

        Assert.NotNull(instances);
        Assert.NotEmpty(instances);
        Assert.InRange(instances.Count(), 3, int.MaxValue);
        Assert.Contains(typeof(MyMockCommandHandler1), instances.Select(s => s.GetType()));
        Assert.Contains(typeof(MyMockCommandHandler2), instances.Select(s => s.GetType()));
        Assert.Contains(typeof(MyMockCommandHandler3), instances.Select(s => s.GetType()));
    }

    #region Stubs
    public class MyCommand : ICommand { }

    public class MyMockCommandHandler1 : CommandHandler<MyCommand>
    {
        protected override Task HandleAsync(MyCommand command)
        {
            throw new NotImplementedException();
        }
    }

    public class MyMockCommandHandler2 : CommandHandler<MyCommand>
    {
        protected override Task HandleAsync(MyCommand command)
        {
            throw new NotImplementedException();
        }
    }

    public class MyMockCommandHandler3 : CommandHandler<MyCommand>
    {
        protected override Task HandleAsync(MyCommand command)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}