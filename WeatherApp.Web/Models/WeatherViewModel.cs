namespace WeatherApp.Web.Models;

public class WeatherViewModel
{
    public required string City { get; init; }
    public required WeatherForecast[] Forecasts { get; init; }
}
