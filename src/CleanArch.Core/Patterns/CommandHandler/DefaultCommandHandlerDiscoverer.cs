// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.Core.Patterns.CommandHandler;

public class DefaultCommandHandlerDiscoverer : ICommandHandlerDiscoverer
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultCommandHandlerDiscoverer(IServiceProvider serviceProvider)
    {
        _serviceProvider = Guard.NotNullArgument(serviceProvider, nameof(serviceProvider));
    }

    public IEnumerable<ICommandHandler> GetCommandHandlersByCommandType(Type commandType)
    {
        Guard.NotNullArgument(commandType, nameof(commandType));

        Type commandHandlerType = null;

        // Busca informações de tipo resolvido em cache
        var cacheEntry = ReadFromCache(commandType);

        if (cacheEntry is not null)
        {
            cacheEntry.ThrowIfException();

            if (cacheEntry.OriginType == commandType && cacheEntry.ResolvedType is not null)
            {
                commandHandlerType = cacheEntry.ResolvedType;
            }
        }

        // Não havendo cache calculamos o tipo
        if (commandHandlerType is null)
        {
            var iCommandInterfaceType = typeof(ICommand);

            if (!commandType.GetInterfaces().Any(i => i == iCommandInterfaceType))
            {
                var exception = new InvalidCastException(
                    $"The command type must be implements {iCommandInterfaceType.Name} interface");

                WriteToCache(commandType, exception);

                throw exception;
            }

            commandHandlerType = typeof(CommandHandler<>).MakeGenericType(commandType);

            // Guarda informações de tipo resolvido em cache
            WriteToCache(commandType, commandHandlerType);
        }

        return _serviceProvider.GetServices<ICommandHandler>()?
            .Where(w => commandHandlerType.Equals(w.GetType().BaseType))
            ?? Enumerable.Empty<ICommandHandler>();
    }

    private CommandHandlerDiscoveryTypeSummary ReadFromCache(Type originType)
    {
        _ = Guard.NotNullArgument(originType, nameof(originType));

        // TODO: Buscar do cache caso serviço de cache esteja configurado
        // Microsoft.Extensions.Caching.Memory.IMemoryCache + _serviceProvider

        return null;
    }

    private void WriteToCache(Type originType, Type resolvedType)
    {
        _ = Guard.NotNullArgument(originType, nameof(originType));
        _ = Guard.NotNullArgument(resolvedType, nameof(resolvedType));

        // TODO: Gravar do cache caso serviço de cache esteja configurado
        // Microsoft.Extensions.Caching.Memory.IMemoryCache + _serviceProvider
    }

    private void WriteToCache(Type originType, Exception exception)
    {
        _ = Guard.NotNullArgument(originType, nameof(originType));
        _ = Guard.NotNullArgument(exception, nameof(exception));

        // TODO: Gravar do cache caso serviço de cache esteja configurado
        // Microsoft.Extensions.Caching.Memory.IMemoryCache + _serviceProvider
    }
}