// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace EmptyCoreLibrary;

/// <summary>
/// Classe de exemplo na biblioteca
/// </summary>
/// <remarks>
/// Sempre documente suas classes. Essa é a documentação de desenvolvimento principal.
/// </remarks>
public class MyClass
{
    private readonly object _instance;

    public MyClass(object instance)
    {
        _instance = Guard.NotNullArgument(instance, nameof(instance));
    }
}