// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.Core;

/// <summary>
/// Um evento que pode ser manipulado posteriormente
/// </summary>
/// <remarks>
/// Um evento nada mais é do que um comando, e um comando é a
/// descrição de uma ação que pode ou não ser executada no futuro
/// através de um <see cref="ICommandHandler{TCommand}"/>
/// </remarks>
public interface IEvent : ICommand { }