// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.CommandHandler;

namespace CleanArch.Application;

/// <summary>
/// Um ator que realiza operações negociais
/// </summary>
public class BusinessActor
{
    private readonly ICommandHandlerDiscoverer _commandHandlerDiscoverer;

    public BusinessActor(ICommandHandlerDiscoverer commandHandlerDiscoverer)
    {
        _commandHandlerDiscoverer = Guard.NotNullArgument(
            commandHandlerDiscoverer, nameof(commandHandlerDiscoverer));
    }

    /// <summary>
    /// Executa todos os manipuladores disponíveis para os comandos informados
    /// </summary>
    /// <param name="commands">Lista de comandos para manipular</param>
    /// <returns>Resumo da execução</returns>
    protected async Task<HandleCommandsSummary> HandleAllCommandsAsync(IEnumerable<ICommand> commands)
    {
        _ = Guard.NotNullArgument(commands, nameof(commands));

        HandleCommandsSummary summary = new();

        var indexedCommands = commands.Where(w => w is not null)
            .Select((v, i) => new { Value = v, Index = i });

        var lastIndex = 0;

        foreach (var cmdIterator in indexedCommands)
        {
            // Em caso de falha na execução anterior, a iteração deve ser
            // encerrada imediatamente
            if (!summary.IsSuccess)
            {
                break;
            }

            lastIndex = cmdIterator.Index;

            Type commandType = cmdIterator.Value.GetType();
            var commandHandlers = _commandHandlerDiscoverer.GetCommandHandlersByCommandType(commandType);

            if (commandHandlers is null || !commandHandlers.Any())
            {
                summary.ReportUnhandled(cmdIterator.Value);

                continue;
            }

            foreach (var commandHandler in commandHandlers)
            {
                try
                {
                    await commandHandler.HandleAsync(cmdIterator.Value);

                    summary.ReportSuccess(cmdIterator.Value, commandHandler);
                }
                catch (Exception ex)
                {
                    summary.ReportFailure(cmdIterator.Value, commandHandler, ex);
                    break;
                }
            }
        }

        // Percorrendo os comandos restantes apenas para informar
        // a não execução dos mesmos
        foreach (var cmdIterator in indexedCommands.Where(w => w.Index > lastIndex))
        {
            summary.ReportUnhandled(cmdIterator.Value);
        }

        return summary;
    }
}