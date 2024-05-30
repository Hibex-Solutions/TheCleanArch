// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Enterprise.DomainDrivenDesign;

/// <summary>
/// Um agregado de domínio
/// </summary>
public abstract class DomainAggregate<TRootEntity> : IDomainAggregate
    where TRootEntity : IDomainEntity
{
    /// <summary>
    /// Entidade raiz do agregado
    /// </summary>
    public TRootEntity RootEntity { get; protected set; }
}