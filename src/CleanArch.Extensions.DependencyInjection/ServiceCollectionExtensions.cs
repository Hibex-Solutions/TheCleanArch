// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Linq;
using System.Reflection;

using CleanArch.Core;
using CleanArch.Core.Patterns.GuardClauses;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArch.Extensions.DependencyInjection;

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
            var cmdHandlerInterfaces = cmdHandlerType.GetInterfaces()
                .Where(t => t.IsGenericType && cmdHandlerInterfaceType == t.GetGenericTypeDefinition());

            foreach (var cmdHandlerInterface in cmdHandlerInterfaces)
            {
                services.TryAddScoped(cmdHandlerInterface, cmdHandlerType);
            }
        };

        return services;
    }
}