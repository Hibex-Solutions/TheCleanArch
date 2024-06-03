using TheCleanArch.Application.PortsAndAdapters;

namespace GettingStarted;

/// <summary>
/// Obtém um bom nome para a temperatura informada em Graus Celsius
/// </summary>
public class GetGoodNameForTemperatureUseCase : InboundPortHandler<int, string>
{
    public override Task<string> HandleAsync(int input, CancellationToken cancellationToken = default)
    {
        var summaries = new[]
        {
            "Freezing", // < -9
            "Bracing", // between -9 and 0
            "Chilly", // between 1 and 10
            "Cool", // between 11 and 18
            "Mild", // between 19 and 26
            "Warm", // between 27 and 33
            "Balmy", // between 34 and 37
            "Hot", // between 38 and 41
            "Sweltering", // between 42 and 45
            "Scorching" // > 45
        };

        if (input < -9) return Task.FromResult(summaries[0]);

        if (input >= -9 && input <= 0) return Task.FromResult(summaries[1]);
        if (input >= 1 && input <= 10) return Task.FromResult(summaries[2]);
        if (input >= 11 && input <= 18) return Task.FromResult(summaries[3]);
        if (input >= 19 && input <= 26) return Task.FromResult(summaries[4]);
        if (input >= 27 && input <= 33) return Task.FromResult(summaries[5]);
        if (input >= 34 && input <= 37) return Task.FromResult(summaries[6]);
        if (input >= 38 && input <= 41) return Task.FromResult(summaries[7]);
        if (input >= 42 && input <= 45) return Task.FromResult(summaries[8]);
        
        return Task.FromResult(summaries[9]);
    }
}
