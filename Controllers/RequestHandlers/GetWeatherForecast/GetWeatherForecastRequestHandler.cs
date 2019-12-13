using System.Threading;
using System.Threading.Tasks;
using DarkSky.Models;
using DarkSky.Services;
using MediatR;

namespace WeatherApiTest.Controllers.RequestHandlers.GetWeatherForecast {
  public class GetWeatherForecastRequestHandler : IRequestHandler<GetWeatherForecastRequest, Forecast> {
    private readonly DarkSkyService _weatherService;

    public GetWeatherForecastRequestHandler(DarkSkyService weatherService) {
      _weatherService = weatherService;
    }

    public async Task<Forecast> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken) {
      var forecast = await _weatherService.GetForecast(37.8267, -122.4233);

      return forecast.Response;
    }
  }
}
