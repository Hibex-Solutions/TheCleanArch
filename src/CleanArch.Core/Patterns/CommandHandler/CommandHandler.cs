// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.Core;

/// <summary>
/// Um manipulador de comando <see cref="TCommand"/>
/// </summary>
public abstract class CommandHandler<TCommand> : ICommandHandler
    where TCommand : ICommand
{
    public Task HandleAsync(object command)
    {
        _ = Guard.NotNullArgument(command, nameof(command));

        return command is TCommand
            ? HandleAsync(command is TCommand)
            : throw new InvalidCastException(
                $"The command must be of type {typeof(TCommand).Name} " +
                $"to be handled by {typeof(CommandHandler<TCommand>).Name}");
    }

    protected abstract Task HandleAsync(TCommand command);
}