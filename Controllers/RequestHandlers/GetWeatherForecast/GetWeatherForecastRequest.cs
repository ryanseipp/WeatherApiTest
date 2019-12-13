using DarkSky.Models;
using MediatR;

namespace WeatherApiTest.Controllers.RequestHandlers.GetWeatherForecast {
  public class GetWeatherForecastRequest : IRequest<Forecast> {
    public GetWeatherForecastRequest() { }
  }
}
