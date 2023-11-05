// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
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
    private List<DomainEvent> _domainEventList;

    /// <summary>
    /// Identificador da entidade
    /// </summary>
    public TId Id { get; protected set; }

    /// <summary>
    /// Obtem eventos de domínio exportados pela entidade
    /// </summary>
    /// <remarks>Nunca é um valor nulo</remarks>
    public IReadOnlyCollection<DomainEvent> GetExportedDomainEvents()
    => (_domainEventList ??= new List<DomainEvent>()).AsReadOnly();

    /// <summary>
    /// Obtém a lista de eventos para manipulação
    /// </summary>
    /// <remarks>Nunca é um valor nulo</remarks>
    protected List<DomainEvent> GetDomainEventList()
    => _domainEventList ??= new List<DomainEvent>();
}