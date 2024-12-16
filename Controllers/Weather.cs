using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{

    private readonly IWeatherService _weatherService;


    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IActionResult GetWeather()
    {
        var weatherData = _weatherService.GetWeatherData();
        return Ok(weatherData);
    }

    [HttpGet("{city}")]
    public IActionResult GetWeatherByCity(string city)
    {
        var weatherData = _weatherService.GetWeatherByCity(city);

        if (weatherData == null)
        {
            return NotFound(new { Message = $"No weather data found for city: {city}" });
        }

        return Ok(weatherData);
    }



    [HttpGet("temperature/{temperature}")]
    public IActionResult GetWeatherByTemperature(float temperature)
    {
        var weatherData = _weatherService.GetWeatheByTemperature(temperature);

        if (weatherData == null)
        {
            return NotFound(new { Message = $"No weather data found for temperature: {temperature}" });
        }

        return Ok(weatherData);
    }
}
