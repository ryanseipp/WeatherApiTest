using System;
using System.Threading.Tasks;
using DarkSky.Models;

namespace WeatherApiTest {
  public interface IWeatherService : IDisposable {
    public Task<DarkSkyResponse> GetForecast(double latitude, double longitude,
      OptionalParameters parameters = null);
  }
}
