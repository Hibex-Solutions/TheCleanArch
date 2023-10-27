// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um repositório de domínio para agregado
/// </summary>
/// <typeparam name="TAggregate">Tipo do agregado</typeparam>
/// <typeparam name="TEntity">Tipo da entidade raiz</typeparam>
public interface IDomainRepository<TAggregate, TEntity> : IDomainRepository
    where TAggregate : DomainAggregate<TEntity>
    where TEntity : IDomainEntity
{ }