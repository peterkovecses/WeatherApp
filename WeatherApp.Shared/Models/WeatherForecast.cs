namespace WeatherApp.Shared.Models;

public class WeatherForecast
{
    public string City { get; set; } = default!;
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public int Humidity { get; set; }
    public int WindKph { get; set; }
    public int WindMph => (int)(WindKph * 0.621371192);
    public string? Summary { get; set; }
}
