// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um serviço de domínio
/// </summary>
public abstract class DomainService
{
    private readonly List<DomainEvent> _emittedDomainEvents;

    public DomainService()
    {
        _emittedDomainEvents = new List<DomainEvent>();
    }

    /// <summary>
    /// Eventos de domínio emitidos em uma operação
    /// </summary>
    public IReadOnlyCollection<DomainEvent> EmittedDomainEvents
    {
        get => _emittedDomainEvents.AsReadOnly();
    }
}