// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.GuardClauses;

namespace CleanArch.DomainDrivenDesign;

public class EventEmittingObject
{
    /// <summary>
    /// Lista de eventos emitidos
    /// </summary>
    /// <remarks>
    /// A lista só é instanciada se precisar ser usada. Isso é feito através
    /// do método <see cref="GetEmittedDomainEventsList"/>.
    /// </remarks>
    private List<DomainEvent> _emittedDomainEvents;

    /// <summary>
    /// Eventos de domínio emitidos em uma operação
    /// </summary>
    /// <remarks>Nunca é um valor nulo</remarks>
    protected IReadOnlyCollection<DomainEvent> EmittedDomainEvents
    {
        get => GetEmittedDomainEventsList().AsReadOnly();
    }

    /// <summary>
    /// Adiciona um evento a lista de eventos emitidos
    /// </summary>
    /// <param name="domainEvent">Instância de evento a adicionar</param>
    /// <exception cref="ArgumentException">Quando <paramref name="domainEvent"/> é nulo</exception>
    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        Guard.NotNullArgument(domainEvent, nameof(domainEvent));

        var emittedDomainEventList = GetEmittedDomainEventsList();

        if (emittedDomainEventList.Contains(domainEvent))
        {
            return;
        }

        emittedDomainEventList.Add(domainEvent);
    }

    /// <summary>
    /// Remove um evento da lista de eventos emitidos
    /// </summary>
    /// <param name="domainEvent">Instância de evento a remover</param>
    /// <exception cref="ArgumentException">Quando <paramref name="domainEvent"/> é nulo</exception>
    protected void RemoveDomainEvent(DomainEvent domainEvent)
    {
        Guard.NotNullArgument(domainEvent, nameof(domainEvent));

        GetEmittedDomainEventsList().Remove(domainEvent);
    }

    /// <summary>
    /// Garante o retorno de uma lista de eventos emitidos
    /// </summary>
    /// <returns>Lista de eventos de domínio</returns>
    protected List<DomainEvent> GetEmittedDomainEventsList() => _emittedDomainEvents ??= new List<DomainEvent>();
}