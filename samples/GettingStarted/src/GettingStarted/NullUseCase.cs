using TheCleanArch.Application.PortsAndAdapters;

namespace GettingStarted;

/// <summary>
/// Exemplo de caso de uso sem dados de entrada ou saída
/// </summary>
public class NullUseCase : InboundPortHandler
{
    public override Task<NullPortData> HandleAsync(NullPortData input = null!, CancellationToken cancellationToken = default)
    {
        // Este é um exemplo de uma operação qualquer que não recebe nem dados de
        // entrada, nem retorna dados de saída em um caso de uso

        return Task.FromResult(NullPortData.Instance);
    }
}
