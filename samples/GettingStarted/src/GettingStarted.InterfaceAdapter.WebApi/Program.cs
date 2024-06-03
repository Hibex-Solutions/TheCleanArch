using Microsoft.AspNetCore.Mvc;

namespace GettingStarted.InterfaceAdapter.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapGet("/weatherforecast", async (HttpContext httpContext) =>
        {
            _ = Guard.NotNullArgument(httpContext, nameof(httpContext));

            var useCase = new GetGoodNameForTemperatureUseCase();

            List<WeatherForecast> forecast = new();

            foreach (int index in Enumerable.Range(1, 5))
            {
                int temperatureC = Random.Shared.Next(-20, 55);
                string goodName = await useCase.HandleAsync(temperatureC);

                forecast.Add(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = temperatureC,
                    Summary = goodName
                });
            }

            return forecast;
        })
        .WithName("GetWeatherForecast");

        app.MapGet("/null", async () =>
        {
            var useCase = new NullUseCase();

            _ = await useCase.HandleAsync();

            return Results.Ok();
        });

        app.Run();
    }
}
