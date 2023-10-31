// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Threading.Tasks;

namespace CleanArch.Core;

/// <summary>
/// Um manipulador de comando <see cref="TCommand"/>
/// </summary>
public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}