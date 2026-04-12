// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Core.Patterns.GuardClauses;

namespace TheCleanArch.Core;

/// <summary>
/// Identifica a camada de arquitetura em um <see cref="Assembly"/> 
/// </summary>
/// <remarks>
/// Você deve identificar no <see cref="Assembly"/> a qual camada da arquitetura
/// cada projeto pertence. Isso será útil na verificação de integridade com
/// relação "A Regra de Dependência" definida em "The Clean Arch".
/// </remarks>
/// <example>
/// Exemplo de uso em um arquivo <c>AssemblyInfo.cs</c> na camada <see cref="ArchLayerId.Enterprise"/>.
///
/// <code language="csharp">
/// using static TheCleanArch.Core.ArchLayerId;
///
/// [assembly: ArchLayer(Enterprise, nameof(Enterprise))]
/// </code> 
/// </example>
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