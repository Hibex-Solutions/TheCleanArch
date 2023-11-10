// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.Core.Patterns.CommandHandler;

/// <summary>
/// Descobridor de manipuladores de comando
/// </summary>
public interface ICommandHandlerDiscoverer
{
    IEnumerable<ICommandHandler> GetCommandHandlersByCommandType(Type commandType);
}