// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um evento de domínio
/// </summary>
/// <remarks>
/// <para>Um evento de domínio sempre tem um identificador único e ocorre em um
/// momento específico do tempo.</para>
/// <para>A definição do evento de domínio em si é dada pelo próprio tipo que
/// o</para>
/// </remarks>
public abstract class DomainEvent
{
    public DomainEvent(DateTimeOffset createdAt)
    {
        Id = Guid.NewGuid();
        CreatedAt = createdAt;
    }

    public DomainEvent(Guid id, DateTimeOffset createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
}