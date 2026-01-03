// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Application.PortsAndAdapters;

/// <summary>
/// Um manipulador para porta de entrada da camada de aplicação
/// </summary>
/// <remarks>Com dados de saída mas sem dados de entrada</remarks>
public abstract class OutputOnlyInboundPortHandler<TOutput> : IInboundPort
{
    public abstract Task<TOutput> HandleAsync(CancellationToken cancellationToken = default);
}