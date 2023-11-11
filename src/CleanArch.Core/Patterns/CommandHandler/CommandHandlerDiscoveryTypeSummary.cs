// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.Core.Patterns.CommandHandler;

public class CommandHandlerDiscoveryTypeSummary
{
    public CommandHandlerDiscoveryTypeSummary(Type originType, Exception exception)
    {
        OriginType = Guard.NotNullArgument(originType, nameof(originType));
        Exception = Guard.NotNullArgument(exception, nameof(exception));
    }

    public CommandHandlerDiscoveryTypeSummary(Type originType, Type resolvedType)
    {
        OriginType = Guard.NotNullArgument(originType, nameof(originType));
        ResolvedType = Guard.NotNullArgument(resolvedType, nameof(resolvedType));
    }

    public Exception Exception { get; private set; }
    public Type OriginType { get; private set; }
    public Type ResolvedType { get; private set; }

    public void ThrowIfException()
    {
        if (Exception is null)
        {
            return;
        }

        throw Exception;
    }
}