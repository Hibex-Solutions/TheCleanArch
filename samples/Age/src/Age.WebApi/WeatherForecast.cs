// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch Samples.
// Licensed under the Apache version 2.0: LICENSE file.

namespace Age.WebApi;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}