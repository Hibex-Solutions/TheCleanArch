// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Threading.Tasks;

namespace CleanArch.Core;

/// <summary>
/// Um manipulador de evento personalizado
/// </summary>
public interface ICustomEventHandler<TCustomEvent>
    where TCustomEvent : IHandleableCustomEvent
{
    Task HandleAsync(TCustomEvent customEvent);
}