// Copyright (c) Hibex Solutions. All rights reserved.
// This file is a part of CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using CleanArch.Core.Patterns.CommandHandler;

using Microsoft.Extensions.DependencyInjection;

using Moq;

namespace CleanArch.Application.Tests;

[Trait("target", nameof(BusinessActor))]
public class BusinessActorTest
{
    [Fact(DisplayName = "Requires not null commands")]
    public async Task HandleAllCommandsAsync_RequiresNotNullCommands()
    {
        var commandHandlerDiscovererMock = new Mock<ICommandHandlerDiscoverer>();
        var stub = new BusinessActorExecutorStub(commandHandlerDiscovererMock.Object, null);

        var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () => await stub.ExecuteAsync());

        Assert.NotNull(ex);
        Assert.Equal("commands", ex.ParamName);
    }

    [Fact(DisplayName = "Returns an empty summary for an empty command list")]
    public async Task HandleAllCommandsAsync_ReturnsAnEmptySummaryForAnEmptyCommandList()
    {
        var commandHandlerDiscovererMock = new Mock<ICommandHandlerDiscoverer>();

        var stub = new BusinessActorExecutorStub(commandHandlerDiscovererMock.Object, Enumerable.Empty<ICommand>());

        var summary = await stub.ExecuteAsync();

        Assert.NotNull(summary);
        Assert.Empty(summary.HandledCommands);
        Assert.Empty(summary.UnhandledCommands);
    }

    [Fact(DisplayName = "Discard null commands")]
    public async Task HandleAllCommandsAsync_DiscardNullCommands()
    {
        var commandHandlerDiscovererMock = new Mock<ICommandHandlerDiscoverer>();

        List<ICommand> nullCommandsList = new(){
            null, null, null
        };

        var stub = new BusinessActorExecutorStub(commandHandlerDiscovererMock.Object, nullCommandsList);

        var summary = await stub.ExecuteAsync();

        Assert.NotNull(summary);
        Assert.Empty(summary.HandledCommands);
        Assert.Empty(summary.UnhandledCommands);
    }

    [Fact(DisplayName = "Any exception in the handlers fails the entire execution")]
    public async Task AnyExceptionInTheHandlers_FailsTheEntireExecution()
    {
        var collection = new ServiceCollection().AddCleanArchDefaults();

        collection.AddScoped<ICommandHandler, MyThrowExceptionCommandHandler>(_ =>
            new MyThrowExceptionCommandHandler(new Exception("Exceção do manipulador!")));

        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var commandHandlerDiscoverer = serviceProvider.GetService<ICommandHandlerDiscoverer>();

        var commandList = new List<ICommand>(){
            new MyCommand(),
            new MyCommand()
        };

        var stub = new BusinessActorExecutorStub(commandHandlerDiscoverer, commandList);

        var summary = await stub.ExecuteAsync();

        (ICommand commandError,
            ICommandHandler commandHandlerError,
            Exception commandExceptionError) = summary.Failure.Value;

        Assert.NotNull(summary);
        Assert.False(summary.IsSuccess);
        Assert.NotNull(summary.Failure);
        Assert.NotNull(commandError);
        Assert.NotNull(commandHandlerError);
        Assert.NotNull(commandExceptionError);
        Assert.Equal(0, summary.HandledCommands.Count);
        Assert.Equal(2, summary.UnhandledCommands.Count);
        Assert.Equal(commandList.Count, summary.HandledCommands.Count + summary.UnhandledCommands.Count);
        Assert.Equal("Exceção do manipulador!", commandExceptionError?.Message);
    }


    [Fact(DisplayName = "Successful executions must be reported")]
    public async Task SuccessfulExecutionsMustBeReported()
    {
        var collection = new ServiceCollection().AddCleanArchDefaults();

        collection.AddScoped<ICommandHandler, MySuccessCommandHandler>();

        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var commandHandlerDiscoverer = serviceProvider.GetService<ICommandHandlerDiscoverer>();

        var cmd1 = new MyCommand();
        var cmd2 = new MyCommand();
        var cmd3 = new MyCommand();

        var commandList = new List<ICommand>(){
            cmd1, cmd2, cmd3
        };

        var stub = new BusinessActorExecutorStub(commandHandlerDiscoverer, commandList);

        var summary = await stub.ExecuteAsync();

        Assert.NotNull(summary);
        Assert.True(summary.IsSuccess);
        Assert.Null(summary.Failure);
        Assert.Equal(3, summary.HandledCommands.Count);
        Assert.Equal(0, summary.UnhandledCommands.Count);

        Assert.NotNull(summary.HandledCommands[cmd1]);
        Assert.NotNull(summary.HandledCommands[cmd2]);
        Assert.NotNull(summary.HandledCommands[cmd3]);

        Assert.Single(summary.HandledCommands[cmd1]);
        Assert.Single(summary.HandledCommands[cmd2]);
        Assert.Single(summary.HandledCommands[cmd3]);

        Assert.IsType<MySuccessCommandHandler>(summary.HandledCommands[cmd1].Single());
        Assert.IsType<MySuccessCommandHandler>(summary.HandledCommands[cmd2].Single());
        Assert.IsType<MySuccessCommandHandler>(summary.HandledCommands[cmd2].Single());
    }

    [Fact(DisplayName = "Command without handler does not generate failure but must be registered")]
    public async Task CommandWithoutHandlerDoesNotGenerateFailure_ButMustBeRegistered()
    {
        var collection = new ServiceCollection().AddCleanArchDefaults();
        var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(collection);
        var commandHandlerDiscoverer = serviceProvider.GetService<ICommandHandlerDiscoverer>();

        var cmd1 = new MyCommand();
        var cmd2 = new MyCommand();
        var cmd3 = new MyCommand();

        var commandList = new List<ICommand>(){
            cmd1, cmd2, cmd3
        };

        var stub = new BusinessActorExecutorStub(commandHandlerDiscoverer, commandList);

        var summary = await stub.ExecuteAsync();

        Assert.NotNull(summary);
        Assert.True(summary.IsSuccess);
        Assert.Null(summary.Failure);
        Assert.Equal(0, summary.HandledCommands.Count);
        Assert.Equal(3, summary.UnhandledCommands.Count);

        Assert.Contains(cmd1, summary.UnhandledCommands);
        Assert.Contains(cmd2, summary.UnhandledCommands);
        Assert.Contains(cmd3, summary.UnhandledCommands);
    }

    #region Stubs
    public class BusinessActorExecutorStub : BusinessActor
    {
        private readonly IEnumerable<ICommand> _commands;

        public BusinessActorExecutorStub(
            ICommandHandlerDiscoverer commandHandlerDiscoverer,
            IEnumerable<ICommand> commands) : base(commandHandlerDiscoverer)
            => _commands = commands;

        public async Task<HandleCommandsSummary> ExecuteAsync()
            => await HandleAllCommandsAsync(_commands);
    }

    public class MyCommand : ICommand { }

    public class MySuccessCommandHandler : CommandHandler<MyCommand>
    {
        protected override Task HandleAsync(MyCommand command) => Task.CompletedTask;
    }

    public class MyThrowExceptionCommandHandler : CommandHandler<MyCommand>
    {
        private readonly Exception _exception;

        public MyThrowExceptionCommandHandler(Exception exception)
        {
            _exception = exception;

        }
        protected override Task HandleAsync(MyCommand command)
        {
            throw _exception;
        }
    }
    #endregion
}