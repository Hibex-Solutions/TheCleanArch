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
public class DomainEntity<TId>
{
    /// <summary>
    /// Identificador da entidade
    /// </summary>
    public TId Id { get; protected set; }
}