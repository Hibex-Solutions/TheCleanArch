// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using System;

namespace TheCleanArch.Enterprise.DomainDrivenDesign;

/// <summary>
/// Um evento de domínio
/// </summary>
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
    /// Identificador único do evento
    /// </summary>
    public Guid Id { get; private set; }
}