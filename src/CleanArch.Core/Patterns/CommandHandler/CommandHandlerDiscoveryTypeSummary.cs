// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.Core.Patterns.CommandHandler;

public class CommandHandlerDiscoveryTypeSummary
{
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