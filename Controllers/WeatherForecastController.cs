using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApiTest.Controllers.RequestHandlers.GetCityForecast;
using WeatherApiTest.Controllers.RequestHandlers.GetWeatherForecast;

namespace WeatherApiTest.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase {
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger) {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get() {
      var weatherForecastResult = await _mediator.Send(new GetWeatherForecastRequest());

      return Ok(weatherForecastResult);
    }

    [HttpGet("city")]
    public async Task<IActionResult> GetCityForecast([FromQuery] GetCityForecastRequestModel model) {
      var cityForecastResult = await _mediator.Send(new GetCityForecastRequest(model));

      return Ok(cityForecastResult);
    }
  }
}
