// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Core.Patterns.GuardClauses;

namespace TheCleanArch.Core;

/// <summary>
/// Identifica a camada de arquitetura em um <see cref="System.Reflection.Assembly"/> 
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public sealed class ArchLayerAttribute : Attribute
{
    public ArchLayerAttribute(ArchLayerId id, string name)
    {
        Id = id;
        Name = Guard.NotEmptyArgument(name, nameof(name));
    }

    /// <summary>
    /// Identificador da camada
    /// </summary>
    public ArchLayerId Id { get; private set; }

    /// <summary>
    /// Nome da camada
    /// </summary>
    public string Name { get; private set; }
}