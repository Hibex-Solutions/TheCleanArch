// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um agregado de entidades relacionadas e dependentes
/// </summary>
public abstract class DomainAggregate<TRootEntity>
    where TRootEntity : IDomainEntity
{
    /// <summary>
    /// Entidade raiz
    /// </summary>
    public TRootEntity RootEntity { get; protected set; }

    /// <summary>
    /// Obtém todos os eventos de domínio exportados pelas entidades envolvidas
    /// no agregado
    /// </summary>
    /// <returns>Uma lista de eventos de domínio</returns>
    protected abstract IEnumerable<DomainEvent> GetAllExportedDomainEvents();

    /// <summary>
    /// Tenta obter o próximo evento de domínio ainda não comprometido
    /// </summary>
    /// <param name="domainEvent">Evento de saída</param>
    /// <returns>True quando conseguir o evento e false caso contrário</returns>
    public bool TryGetNextNonCommittedDomainEvent(out DomainEvent domainEvent)
    {
        domainEvent = GetAllExportedDomainEvents()?
            .FirstOrDefault(w => !w.Committed);

        return domainEvent is not null;
    }
}