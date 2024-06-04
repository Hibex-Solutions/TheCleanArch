// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Application.PortsAndAdapters;

/// <summary>
/// Um manipulador para porta de entrada da camada de aplicação
/// </summary>
public abstract class InboundPortHandler : IInboundPort
{
    public abstract Task HandleAsync(CancellationToken cancellationToken = default);
}