// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Core;

/// <summary>
/// Coletor de eventos personalizad
/// </summary>
/// <remarks>
/// Um objeto que é capaz de coletar eventos personalizados emitidos por si
/// ou por outros objetos que ele controla
/// </remarks>
public interface ICustomEventCollector
{
    /// <summary>
    /// Coleta uma lista de eventos personalizados emitidos
    /// </summary>
    /// <returns>Uma lista de eventos customizáveis</returns>
    Task<IReadOnlyCollection<IHandleableCustomEvent>> CollectEmittedCustomEvents();
}