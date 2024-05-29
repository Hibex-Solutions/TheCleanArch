// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Core;

/// <summary>
/// Nomes para as camadas da arquitetura
/// </summary>
public static class ArchLayerNames
{
    /// <summary>
    /// Nome original da camada de regras organizacionais
    /// </summary>
    public static class Enterprise
    {
        public const ArchLayerId Id = ArchLayerId.Enterprise;
        public const string Name = nameof(Enterprise);
    }

    /// <summary>
    /// A camada de regras organizacionais também é conhecida como "Domain"
    /// </summary>
    public static class Domain
    {
        public const ArchLayerId Id = ArchLayerId.Enterprise;
        public const string Name = nameof(Domain);
    }

    /// <summary>
    /// Nome original da camada com regras de aplicação
    /// </summary>
    public static class Application
    {
        public const ArchLayerId Id = ArchLayerId.Application;
        public const string Name = nameof(Application);
    }

    /// <summary>
    /// A camada de regras de aplicação também é conhecida como "UseCases"
    /// </summary>
    public static class UseCases
    {
        public const ArchLayerId Id = ArchLayerId.Application;
        public const string Name = nameof(UseCases);
    }

    /// <summary>
    /// Nome original da camada com adaptadores de interface
    /// </summary>
    public static class InterfaceAdapter
    {
        public const ArchLayerId Id = ArchLayerId.InterfaceAdapter;
        public const string Name = nameof(InterfaceAdapter);
    }

    /// <summary>
    /// A camada de adaptadores de interfacea também é conhecida como "Infrastructure"
    /// </summary>
    public static class Infrastructure
    {
        public const ArchLayerId Id = ArchLayerId.InterfaceAdapter;
        public const string Name = nameof(Infrastructure);
    }

    /// <summary>
    /// Nome original da camada externa
    /// </summary>
    public static class External
    {
        public const ArchLayerId Id = ArchLayerId.External;
        public const string Name = nameof(External);
    }

    /// <summary>
    /// A camada externa também é conhecida como "Drivers"
    /// </summary>
    public static class Drivers
    {
        public const ArchLayerId Id = ArchLayerId.External;
        public const string Name = nameof(Drivers);
    }

    /// <summary>
    /// A camada externa também é conhecida como "Frameworks"
    /// </summary>
    public static class Frameworks
    {
        public const ArchLayerId Id = ArchLayerId.External;
        public const string Name = nameof(Frameworks);
    }
}