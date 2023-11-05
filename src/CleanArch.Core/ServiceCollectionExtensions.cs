// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCleanArchDefaults(this IServiceCollection services)
    {
        _ = Guard.NotNullArgument(services, nameof(services));

        services.AddScoped<ITimeProvider, DefaultTimeProvider>();

        return services;
    }

    public static IServiceCollection AddCleanArchCommandHandlersFromAssembly(
        this IServiceCollection services,
        Assembly assembly)
    {
        _ = Guard.NotNullArgument(services, nameof(services));
        _ = Guard.NotNullArgument(assembly, nameof(assembly));

        var cmdHandlerInterfaceType = typeof(ICommandHandler<>);
        var cmdHandlerImplementationTypes = assembly.DefinedTypes
            .Where(t => t.GetInterfaces().Any(tt =>
                tt.IsGenericType && cmdHandlerInterfaceType == tt.GetGenericTypeDefinition()));

        foreach (var cmdHandlerType in cmdHandlerImplementationTypes)
        {
            foreach (var cmdHandlerInterface in cmdHandlerType.GetInterfaces()
                .Where(t => t.IsGenericType && cmdHandlerInterfaceType == t.GetGenericTypeDefinition()))
            {
                services.AddScoped(cmdHandlerInterface, cmdHandlerType);
            }
        };

        return services;
    }
}