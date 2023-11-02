// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Uma entidade de domínio
/// </summary>
/// <remarks>
/// <para>Uma entidade de domínio sempre tem um identificador único.</para>
/// <para>A entidade de domínio em si é definida por sua própria implementação
/// concreta, que tem suas características e regras próprias.</para>
/// </remarks>
public abstract class DomainEntity<TId> : IDomainEntity
{
    /// <summary>
    /// Lista de eventos de domínio
    /// </summary>
    /// <remarks>
    /// A lista só é instanciada se precisar ser usada. Isso é feito através
    /// do método <see cref="GetEmittedDomainEventsList"/>.
    /// </remarks>
    private List<DomainEvent> _domainEvents;

    /// <summary>
    /// Identificador da entidade
    /// </summary>
    public TId Id { get; protected set; }

    /// <summary>
    /// Obtem eventos de domínio exportados pela entidade
    /// </summary>
    /// <remarks>Nunca é um valor nulo</remarks>
    public IReadOnlyCollection<DomainEvent> GetExportedDomainEvents()
    {
        return (_domainEvents ??= new List<DomainEvent>()).AsReadOnly();
    }

    /// <summary>
    /// Lista de eventos para manipulação
    /// </summary>
    /// <remarks>Nunca é um valor nulo</remarks>
    protected List<DomainEvent> DomainEvents
    {
        get => _domainEvents ??= new List<DomainEvent>();
    }
}