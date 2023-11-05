// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
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
    public abstract IEnumerable<DomainEvent> GetAllExportedDomainEvents();
}