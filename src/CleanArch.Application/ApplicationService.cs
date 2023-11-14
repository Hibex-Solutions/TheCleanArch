// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.CommandHandler;

namespace CleanArch.Application;

/// <summary>
/// Um serviço de aplicação de negócio
/// </summary>
public class ApplicationService : BusinessActor
{
    public ApplicationService(ICommandHandlerDiscoverer commandHandlerDiscoverer)
        : base(commandHandlerDiscoverer)
    { }
}