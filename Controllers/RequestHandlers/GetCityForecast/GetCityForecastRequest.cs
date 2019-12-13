using DarkSky.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApiTest.Controllers.RequestHandlers.GetCityForecast {
  public class GetCityForecastRequest : IRequest<ActionResult<Forecast>> {
    public GetCityForecastRequestModel Model { get; }

    public GetCityForecastRequest(GetCityForecastRequestModel model) {
      Model = model;
    }
  }
}
