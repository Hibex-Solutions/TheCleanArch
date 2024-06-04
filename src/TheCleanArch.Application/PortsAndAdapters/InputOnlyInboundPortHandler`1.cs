// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Application.PortsAndAdapters;

/// <summary>
/// Um manipulador para porta de entrada da camada de aplicação
/// </summary>
/// <remarks>Com dados de entrada mas sem dados de saída</remarks>
public abstract class InputOnlyInboundPortHandler<TInput> : IInboundPort
{
    public abstract Task HandleAsync(TInput input, CancellationToken cancellationToken = default);
}