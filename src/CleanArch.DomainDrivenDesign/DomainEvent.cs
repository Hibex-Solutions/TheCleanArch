// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
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
public class DomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
    }

    public DomainEvent(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Identificador do evento
    /// </summary>
    public Guid Id { get; private set; }
}