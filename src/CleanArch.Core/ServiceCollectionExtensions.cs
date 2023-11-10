// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.CommandHandler;
using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCleanArchDefaults(this IServiceCollection services)
    {
        _ = Guard.NotNullArgument(services, nameof(services));

        services.AddScoped<ITimeProvider, DefaultTimeProvider>();
        services.AddScoped<ICommandHandlerDiscoverer, DefaultCommandHandlerDiscoverer>();

        return services;
    }

    public static IServiceCollection AddCleanArchCommandHandlersFromAssembly(
        this IServiceCollection services,
        Assembly assembly)
    {
        _ = Guard.NotNullArgument(services, nameof(services));
        _ = Guard.NotNullArgument(assembly, nameof(assembly));

        var commandHandlerInterfaceType = typeof(ICommandHandler);
        var commandHandlerGenericType = typeof(CommandHandler<>);

        var cmdHandlerImplementationTypes = assembly.DefinedTypes.Where(w =>
            commandHandlerInterfaceType.IsAssignableFrom(w) &&
            w.BaseType is not null &&
            w.BaseType.IsGenericType &&
            w.BaseType.GetGenericTypeDefinition().Equals(commandHandlerGenericType));

        foreach (var commandHandlerImplementationType in cmdHandlerImplementationTypes)
        {
            var commandHandlerType = commandHandlerGenericType.MakeGenericType(
                commandHandlerImplementationType.BaseType.GenericTypeArguments);

            services.AddScoped(commandHandlerType, commandHandlerImplementationType);
            services.AddScoped(commandHandlerInterfaceType, commandHandlerImplementationType);
        };

        return services;
    }
}