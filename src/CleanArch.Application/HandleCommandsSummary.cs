// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.


using System.Collections.Immutable;

namespace CleanArch.Application;

/// <summary>
/// Resumo de uma ação para manipulação de comandos
/// </summary>
public class HandleCommandsSummary
{
    private readonly Dictionary<ICommand, List<ICommandHandler>> _handledCommands;
    private readonly List<ICommand> _unhandledCommands;

    public HandleCommandsSummary()
    {
        _handledCommands = new Dictionary<ICommand, List<ICommandHandler>>();
        _unhandledCommands = new List<ICommand>();
    }

    public bool IsSuccess => Failure is null;

    public (ICommand, ICommandHandler, Exception)? Failure { get; private set; }

    public IReadOnlyDictionary<ICommand, IReadOnlyCollection<ICommandHandler>> HandledCommands
    {
        get => _handledCommands.Select(s
            => new KeyValuePair<ICommand, IReadOnlyCollection<ICommandHandler>>(s.Key, s.Value.AsReadOnly()))
            .ToImmutableDictionary();
    }

    public IReadOnlyCollection<ICommand> UnhandledCommands => _unhandledCommands.AsReadOnly();

    internal void ReportSuccess(ICommand command, ICommandHandler commandHandler)
    {
        _ = Guard.NotNullArgument(command, nameof(command));
        _ = Guard.NotNullArgument(commandHandler, nameof(commandHandler));

        if (!_handledCommands.TryGetValue(command, out List<ICommandHandler> commandList))
        {
            _handledCommands.Add(command, new List<ICommandHandler> { commandHandler });

            return;
        }

        commandList.Add(commandHandler);
    }

    /// <summary>
    /// Reporta uma falha no resumo
    /// </summary>
    internal void ReportFailure(ICommand command, ICommandHandler commandHandler, Exception exception)
    {
        _ = Guard.NotNullArgument(command, nameof(command));
        _ = Guard.NotNullArgument(commandHandler, nameof(commandHandler));
        _ = Guard.NotNullArgument(exception, nameof(exception));

        // O comando que gerou a exceção é considerado como não processado
        _unhandledCommands.Add(command);

        Failure = (command, commandHandler, exception);
    }

    /// <summary>
    /// Reporta um comando não manipulado
    /// </summary>
    /// <param name="command"></param>
    internal void ReportUnhandled(ICommand command)
    {
        _ = Guard.NotNullArgument(command, nameof(command));

        _unhandledCommands.Add(command);
    }
}