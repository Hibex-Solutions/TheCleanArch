// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Threading.Tasks;

namespace CleanArch.Core;

/// <summary>
/// Um manipulador de comando <see cref="TCommand"/>
/// </summary>
public interface ICommandHandler<TCommand> : ICommandHandler
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}
