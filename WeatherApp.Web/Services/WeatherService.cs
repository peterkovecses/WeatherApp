namespace WeatherApp.Web.Services;

public class WeatherService(IMemoryCache cache) : IWeatherService
{
    private static readonly WeatherForecast[] PredefinedForecasts =
    [
        new WeatherForecast { TemperatureC = -5, Summary = "Freezing" },
        new WeatherForecast { TemperatureC = -6, Summary = "Freezing" },
        new WeatherForecast { TemperatureC = 0, Summary = "Chilly" },
        new WeatherForecast { TemperatureC = 1, Summary = "Chilly" },
        new WeatherForecast { TemperatureC = 15, Summary = "Cool" },
        new WeatherForecast { TemperatureC = 14, Summary = "Cool" },
        new WeatherForecast { TemperatureC = 22, Summary = "Mild" },
        new WeatherForecast { TemperatureC = 21, Summary = "Mild" },
        new WeatherForecast { TemperatureC = 31, Summary = "Warm" },
        new WeatherForecast { TemperatureC = 30, Summary = "Warm" },
        new WeatherForecast { TemperatureC = 35, Summary = "Hot" },
        new WeatherForecast { TemperatureC = 40, Summary = "Hot" }
    ];

    public WeatherForecast[] GetForecast(string city)
    {   
        var cacheKey = $"forecast_{city}";
        var forecasts = cache.GetOrCreate(cacheKey, entry =>
        {
            entry.AbsoluteExpiration = DateTime.Today.AddDays(1);
            return GenerateForecasts(city);
        });

        return forecasts!;
    }

    private static WeatherForecast[] GenerateForecasts(string city)
    {
        var forecasts = PredefinedForecasts.OrderBy(_ => Guid.NewGuid())
            .Take(5)
            .ToArray();

        var random = new Random();

        for (int i = 0; i < forecasts.Length; i++)
        {
            var forecast = forecasts[i];
            forecasts[i] = new WeatherForecast
            {
                City = city,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                TemperatureC = forecast.TemperatureC,
                Summary = forecast.Summary,
                Humidity = random.Next(20, 81),
                WindKph = random.Next(1, 101)
            };
        }

        return forecasts;
    }
}
