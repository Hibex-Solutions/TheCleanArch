// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core;
using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.DomainDrivenDesign.Patterns.CommandHandler;

/// <summary>
/// Comando para processar eventos de domínio
/// </summary>
/// <remarks>
/// Permite o processamento de eventos de domínio seguindo padrão
/// "Command Handler" e um <see cref="ICommandHandler{TCommand}"/>
/// </remarks>
/// <typeparam name="TDomainEvent"></typeparam>
public class DomainEventProcessorCommand<TDomainEvent> : ICommand
    where TDomainEvent : DomainEvent
{
    public DomainEventProcessorCommand(TDomainEvent domainEvent)
    {
        DomainEvent = Guard.NotNullArgument(domainEvent, nameof(domainEvent));
    }

    public TDomainEvent DomainEvent { get; private set; }
}