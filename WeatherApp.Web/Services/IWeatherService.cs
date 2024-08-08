namespace WeatherApp.Web.Services;

public interface IWeatherService
{
    WeatherForecast[] GetForecast(string city);
}
