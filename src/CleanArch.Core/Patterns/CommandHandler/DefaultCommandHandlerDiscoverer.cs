// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

using Microsoft.Extensions.Caching.Memory;

namespace CleanArch.Core.Patterns.CommandHandler;

public class DefaultCommandHandlerDiscoverer : ICommandHandlerDiscoverer
{
    private readonly IServiceProvider _serviceProvider;
    private IMemoryCache _memoryCache;

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

        return _serviceProvider.GetService<IEnumerable<ICommandHandler>>()?
            .Where(w => commandHandlerType.Equals(w.GetType().BaseType))
            ?? Enumerable.Empty<ICommandHandler>();
    }

    private CommandHandlerDiscoveryTypeSummary ReadFromCache(Type originType)
    {
        _ = Guard.NotNullArgument(originType, nameof(originType));

        var cacheEntry = (typeof(CommandHandlerDiscoveryTypeSummary), originType);

        return (_memoryCache ??= _serviceProvider.GetService<IMemoryCache>()) is null
            ? null
            : _memoryCache.TryGetValue(cacheEntry, out object cacheValue)
            ? cacheValue is CommandHandlerDiscoveryTypeSummary
                ? cacheValue as CommandHandlerDiscoveryTypeSummary
                : null
            : null;
    }

    private void WriteToCache(Type originType, Type resolvedType)
    {
        _ = Guard.NotNullArgument(originType, nameof(originType));
        _ = Guard.NotNullArgument(resolvedType, nameof(resolvedType));

        WriteToCache(
            new CommandHandlerDiscoveryTypeSummary(originType, resolvedType));
    }

    private void WriteToCache(Type originType, Exception exception)
    {
        _ = Guard.NotNullArgument(originType, nameof(originType));
        _ = Guard.NotNullArgument(exception, nameof(exception));

        WriteToCache(
            new CommandHandlerDiscoveryTypeSummary(originType, exception));
    }

    private void WriteToCache(CommandHandlerDiscoveryTypeSummary summary)
    {
        _ = Guard.NotNullArgument(summary, nameof(summary));

        if ((_memoryCache ??= _serviceProvider.GetService<IMemoryCache>()) is null)
        {
            return;
        }

        var cacheEntry = (typeof(CommandHandlerDiscoveryTypeSummary), summary.OriginType);

        _memoryCache.Set(cacheEntry, summary);
    }
}