
using System.Collections.Generic;

public interface IWeatherService
{
    List<WeatherModel> GetWeatherData();
    WeatherModel GetWeatherByCity(string city);
    WeatherModel GetWeatheByTemperature(float temperature);
}
