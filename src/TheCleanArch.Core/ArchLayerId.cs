// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Core;

/// <summary>
/// Identificador de camada de arquitetura
/// </summary>
public enum ArchLayerId
{
    /// <summary>
    /// Camada de regras organizacionais (domínio)
    /// </summary>
    Enterprise,

    /// <summary>
    /// Camada de regras de aplicação
    /// </summary>
    Application,

    /// <summary>
    /// Camada de adaptadores de interface
    /// </summary>
    InterfaceAdapter,

    /// <summary>
    /// Camada externa
    /// </summary>
    External
}