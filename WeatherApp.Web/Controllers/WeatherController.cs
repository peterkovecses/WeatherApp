using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeatherApp.Web.Controllers;

public class WeatherController(IWeatherService weatherService) : Controller
{
    private readonly IWeatherService _weatherService = weatherService;
    private static readonly List<string> Cities = ["New York", "London", "Tokyo", "Berlin", "Paris"];


    public IActionResult Index()
    {
        ViewBag.Cities = new SelectList(Cities);

        return View();
    }

    [HttpPost]
    public IActionResult Index(string city)
    {
        if (string.IsNullOrWhiteSpace(city) || !Cities.Contains(city))
        {
            ModelState.AddModelError("city", "Invalid city selected.");
            ViewBag.Cities = new SelectList(Cities, city);

            return View();
        }

        var forecasts = _weatherService.GetForecast(city);
        ViewBag.Cities = new SelectList(Cities, city);
        var model = new WeatherViewModel
        {
            City = city,
            Forecasts = forecasts
        };

        return View(model);
    }
}
