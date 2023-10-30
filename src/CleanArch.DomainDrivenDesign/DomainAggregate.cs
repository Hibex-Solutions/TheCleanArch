// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System.Threading.Tasks;

using CleanArch.Core;

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um agregado de entidades relacionadas e dependentes
/// </summary>
public abstract class DomainAggregate<TRootEntity> : ICustomEventCollector
    where TRootEntity : IDomainEntity
{
    /// <summary>
    /// Entidade raiz
    /// </summary>
    public TRootEntity RootEntity { get; protected set; }

    /// <summary>
    /// Coleta uma lista assíncrona de eventos personalizados emitidos
    /// </summary>
    /// <returns>Uma lista assíncrona de eventos customizáveis</returns>
    public abstract IAsyncEnumerable<IHandleableCustomEvent> CollectEmittedCustomEvents();
}