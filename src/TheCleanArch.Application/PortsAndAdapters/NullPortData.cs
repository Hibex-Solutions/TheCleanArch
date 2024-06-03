// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace TheCleanArch.Application.PortsAndAdapters;

// TODO: Mover para camada Enterprise
/// <summary>
/// Dado nulo para uso na comunicação com as portas da aplicação
/// <summary>
public class NullPortData
{
    private static NullPortData _instance;

    private NullPortData() { }

    public static NullPortData Instance { get => _instance ??= new NullPortData(); }
}