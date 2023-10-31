// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.Core.Layers;

/// <summary>
/// Identificador da camada na arquitetura
/// </summary>
/// <remarks>
/// Baseado nas definições contidas no artigo "The Clean Architecture"
/// <a href="https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html" />,
/// e obviamente de acordo com nossa própria interpretação
/// </remarks>
public enum LayerId
{
    /// <summary>
    /// Enterprise Business Rules (ex: Entities)
    /// </summary>
    EnterpriseBusinessLayer = 0,

    /// <summary>
    /// Application Business Rules (ex: Use Cases)
    /// </summary>
    ApplicationBusinessLayer = 1,

    /// <summary>
    /// Interface Adapters (ex: Presenters, Controllers, Gateways)
    /// </summary>
    InterfaceAdapterLayer = 2,

    /// <summary>
    /// Frameworks &amp; Drivers (ex: UI, Web, DB, Devices, External Interfaces)
    /// </summary>
    FrameworkLayer = 3
}