// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um serviço de domínio
/// </summary>
public abstract class DomainService : EventEmittingObject
{
    /// <summary>
    /// Eventos de domínio emitidos em uma operação de serviço
    /// </summary>
    /// <remarks>Nunca é um valor nulo</remarks>
    public new IReadOnlyCollection<DomainEvent> EmittedDomainEvents
    {
        get => GetEmittedDomainEventsList().AsReadOnly();
    }

    /// <summary>
    /// Adiciona um evento a lista de eventos emitidos pelo serviço
    /// </summary>
    /// <param name="domainEvent">Instância de evento a adicionar</param>
    /// <exception cref="ArgumentException">Quando <paramref name="domainEvent"/> é nulo</exception>
    protected new void AddDomainEvent(DomainEvent domainEvent) => base.AddDomainEvent(domainEvent);

    /// <summary>
    /// Remove um evento da lista de eventos emitidos pelo serviço
    /// </summary>
    /// <param name="domainEvent">Instância de evento a remover</param>
    /// <exception cref="ArgumentException">Quando <paramref name="domainEvent"/> é nulo</exception>
    protected new void RemoveDomainEvent(DomainEvent domainEvent) => base.RemoveDomainEvent(domainEvent);
}