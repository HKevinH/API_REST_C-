
public class WeatherService : IWeatherService
{

    private readonly List<WeatherModel> _weatherData = new List<WeatherModel>
    {
        new WeatherModel { City = "New York", Country = "CO", Temperature = 5, Condition = "Cloudy", Date = DateTime.Now },
        new WeatherModel { City = "London", Country = "CO", Temperature = 10, Condition = "Rainy", Date = DateTime.Now },
        new WeatherModel { City = "Tokyo", Country = "CO", Temperature = 15, Condition = "Sunny", Date = DateTime.Now }
    };

    public List<WeatherModel> GetWeatherData()
    {
        return _weatherData;
    }

    public WeatherModel GetWeatherByCity(string city)
    {
        return _weatherData.FirstOrDefault(w => w.City?.Equals(city, StringComparison.OrdinalIgnoreCase) == true) ?? new WeatherModel();
    }


    // Is Float
    public WeatherModel GetWeatheByTemperature(float temperature)
    {
        return _weatherData.FirstOrDefault(w => w.Temperature == temperature) ?? new WeatherModel();
    }

}