// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.Core.Layers;

/// <summary>
/// Atributo de identificação de camada conforme CleanArch
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
public sealed class CleanArchLayerIdAttribute : Attribute
{
    public CleanArchLayerIdAttribute(LayerId layerId, string layerName)
    {
        LayerId = layerId;
        LayerName = Guard.NotNullArgument(layerName, nameof(layerName));
    }

    /// <summary>
    /// Identificador da camada
    /// </summary>

    public LayerId LayerId { get; private set; }

    /// <summary>
    /// Nome da camada
    /// </summary>
    public string LayerName { get; private set; }
}