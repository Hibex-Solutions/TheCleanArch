// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um agregado de entidades relacionadas e dependentes
/// </summary>
public abstract class DomainAggregate<TRootEntity>
    where TRootEntity : IDomainAggregateRoot
{
    private List<DomainEvent> _emittedDomainEvents;

    public DomainAggregate()
    {
        _emittedDomainEvents = new List<DomainEvent>();
    }

    /// <summary>
    /// Eventos de domínio emitidos em uma operação
    /// </summary>
    public IReadOnlyCollection<DomainEvent> EmittedDomainEvents
    {
        get => _emittedDomainEvents.AsReadOnly();
        //.ToImmutableList();
        private set => _emittedDomainEvents = value.ToList();
    }

    /// <summary>
    /// Entidade raiz
    /// </summary>
    public IDomainEntity RootEntity { get; private set; }
}