// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um repositório de domínio para entidade raiz
/// </summary>
/// <typeparam name="TRootEntity">Tipo da entidade raiz</typeparam>
public interface IDomainRepository<TRootEntity> : IDomainRepository
    where TRootEntity : IDomainRootEntity
{ }