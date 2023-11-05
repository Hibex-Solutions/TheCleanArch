// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.Core.Layers;

/// <summary>
/// Nomes para camadas da arquitetura
/// </summary>
public static class LayerNames
{

    /// <summary>
    /// Camada de negócios corporativos
    /// </summary>
    public static class EnterpriseLayer
    {
        public const LayerId Id = LayerId.EnterpriseBusinessLayer;
        public const string Name = nameof(EnterpriseLayer);
    }

    /// <summary>
    /// Camada de entidades corporativas
    /// <remarks>Mesmo que <see cref="EnterpriseLayer"/></remarks>
    /// </summary>
    public static class EntityLayer
    {
        public const LayerId Id = EnterpriseLayer.Id;
        public const string Name = nameof(EntityLayer);
    }

    /// <summary>
    /// Camada de domínio quando usando Domain Driven Design
    /// <remarks>Mesmo que <see cref="EnterpriseLayer"/></remarks>
    /// </summary>
    public static class DomainLayer
    {
        public const LayerId Id = EnterpriseLayer.Id;
        public const string Name = nameof(DomainLayer);
    }

    /// <summary>
    /// Camada de aplicação
    /// </summary>
    public static class ApplicationLayer
    {
        public const LayerId Id = LayerId.ApplicationBusinessLayer;
        public const string Name = nameof(ApplicationLayer);
    }

    /// <summary>
    /// Camada de caso de uso de aplicação
    /// </summary>
    /// <remarks>Mesmo que <see cref="ApplicationLayer"/></remarks>
    public static class UseCaseLayer
    {
        public const LayerId Id = ApplicationLayer.Id;
        public const string Name = nameof(UseCaseLayer);
    }

    /// <summary>
    /// Camada de adaptadores de interfaces
    /// </summary>
    public static class InterfaceAdapterLayer
    {
        public const LayerId Id = LayerId.InterfaceAdapterLayer;
        public const string Name = nameof(InterfaceAdapterLayer);
    }

    /// <summary>
    /// Camada de adaptadores de interfaces controladoras
    /// </summary>
    /// <remarks>Mesmo que <see cref="InterfaceAdapterLayer"/></remarks>
    public static class ControllerLayer
    {
        public const LayerId Id = InterfaceAdapterLayer.Id;
        public const string Name = nameof(ControllerLayer);
    }

    /// <summary>
    /// Camada de adaptadores de interfaces apresentadoras
    /// </summary>
    /// <remarks>Mesmo que <see cref="InterfaceAdapterLayer"/></remarks>
    public static class PresenterLayer
    {
        public const LayerId Id = InterfaceAdapterLayer.Id;
        public const string Name = nameof(PresenterLayer);
    }

    /// <summary>
    /// Camada de adaptadores de interfaces gateways
    /// </summary>
    /// <remarks>Mesmo que <see cref="InterfaceAdapterLayer"/></remarks>
    public static class GatewayLayer
    {
        public const LayerId Id = InterfaceAdapterLayer.Id;
        public const string Name = nameof(GatewayLayer);
    }

    /// <summary>
    /// Camada de frameworks e dispositivos
    /// </summary>
    public static class FrameworkLayer
    {
        public const LayerId Id = LayerId.FrameworkLayer;
        public const string Name = nameof(FrameworkLayer);
    }

    /// <summary>
    /// Camada de frameworks e dispositivos de interface com o usuário (UI)
    /// </summary>
    /// <remarks>Mesmo que <see cref="FrameworkLayer"/></remarks>
    public static class UserInterfaceLayer
    {
        public const LayerId Id = FrameworkLayer.Id;
        public const string Name = nameof(UserInterfaceLayer);
    }

    /// <summary>
    /// Camada de frameworks e dispositivos de interface Web
    /// </summary>
    /// <remarks>Mesmo que <see cref="FrameworkLayer"/></remarks>
    public static class WebLayer
    {
        public const LayerId Id = FrameworkLayer.Id;
        public const string Name = nameof(WebLayer);
    }

    /// <summary>
    /// Camada de frameworks e dispositivos mais genéricos
    /// </summary>
    /// <remarks>Mesmo que <see cref="FrameworkLayer"/></remarks>
    public static class DeviceLayer
    {
        public const LayerId Id = FrameworkLayer.Id;
        public const string Name = nameof(DeviceLayer);
    }

    /// <summary>
    /// Camada de frameworks e dispositivos de acesso a dados (DAL)
    /// </summary>
    /// <remarks>Mesmo que <see cref="FrameworkLayer"/></remarks>
    public static class DatabaseLayer
    {
        public const LayerId Id = FrameworkLayer.Id;
        public const string Name = nameof(DatabaseLayer);
    }

    /// <summary>
    /// Camada de frameworks e dispositivos de interface externa
    /// </summary>
    /// <remarks>Mesmo que <see cref="FrameworkLayer"/></remarks>
    public static class ExternalInterfaceLayer
    {
        public const LayerId Id = FrameworkLayer.Id;
        public const string Name = nameof(ExternalInterfaceLayer);
    }
}