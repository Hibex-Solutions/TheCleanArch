// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Core;

/// <summary>
/// Identifica a camada de arquitetura em um <see cref="System.Reflection.Assembly"/> 
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public sealed class ArchLayerAttribute : Attribute
{

}