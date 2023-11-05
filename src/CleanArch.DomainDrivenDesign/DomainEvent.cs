// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core;

namespace CleanArch.DomainDrivenDesign;

/// <summary>
/// Um evento de domínio
/// </summary>
/// <remarks>
/// <para>Um evento de domínio sempre tem um identificador único e ocorre em um
/// momento específico do tempo.</para>
/// <para>A definição do evento de domínio em si é dada pelo próprio tipo que
/// o implementa</para>
/// </remarks>
public class DomainEvent : ICommand
{
    private List<ICommandHandler> _commandHandlers;

    public DomainEvent()
    {
        Id = Guid.NewGuid();
    }

    public DomainEvent(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Identificador do evento
    /// </summary>
    public Guid Id { get; private set; }

    public bool Commited => _commandHandlers is not null && _commandHandlers.Any();

    /// <summary>
    /// Confirma uma manipulação
    /// </summary>
    /// <param name="handler">Manipulador</param>
    public void Commit(ICommandHandler handler)
    {
        _commandHandlers ??= new List<ICommandHandler>();

        if (!_commandHandlers.Contains(handler))
        {
            _commandHandlers.Add(handler);
        }
    }
}