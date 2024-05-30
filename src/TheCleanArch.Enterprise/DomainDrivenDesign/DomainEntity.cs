// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Core.Patterns.GuardClauses;

namespace TheCleanArch.Enterprise.DomainDrivenDesign;

/// <summary>
/// Uma entidade de domínio
/// </summary>
public abstract class DomainEntity<TEntityId> where TEntityId : struct
{
    private readonly List<DomainEvent> _events = new();

    protected DomainEntity(TEntityId id)
    {
        Id = id;
    }

    public TEntityId Id { get; private set; }

    /// <summary>
    /// Adiciona um evento de domínio
    /// </summary>
    /// <remarks>
    /// Caso o evento já tenha sido adicionado (mesmo Id) ele não será duplicado
    /// </remarks>
    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _ = Guard.NotNullArgument(domainEvent, nameof(domainEvent));

        if (_events.Any(e => e.Id == domainEvent.Id))
        {
            return;
        }

        _events.Add(domainEvent);
    }

    protected IReadOnlyCollection<DomainEvent> GetDomainEvents() => _events.AsReadOnly();
}