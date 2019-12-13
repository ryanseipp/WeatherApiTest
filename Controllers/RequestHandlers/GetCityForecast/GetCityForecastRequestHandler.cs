using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DarkSky.Models;
using DarkSky.Services;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApiTest.Controllers.RequestHandlers.GetCityForecast {
  public class GetCityForecastRequestHandler : IRequestHandler<GetCityForecastRequest, ActionResult<Forecast>> {
    private readonly DarkSkyService _weatherService;
    private readonly AddressGeocodeRequest _geocodeRequest;

    public GetCityForecastRequestHandler(DarkSkyService weatherService, AddressGeocodeRequest geocodeRequest) {
      _weatherService = weatherService;
      _geocodeRequest = geocodeRequest;
    }

    public async Task<ActionResult<Forecast>> Handle(GetCityForecastRequest request,
      CancellationToken cancellationToken) {
      _geocodeRequest.Address = $"{request.Model.City}, {request.Model.State}";
      _geocodeRequest.Components = new[] {new KeyValuePair<Component, string>(Component.Country, "US")};
      
      var geocodeData = await GoogleMaps.AddressGeocode.QueryAsync(_geocodeRequest, cancellationToken);
      var location = geocodeData.Results.FirstOrDefault()?.Geometry.Location;

      if (location == null)
        return new BadRequestResult();

      var cityForecast = await _weatherService.GetForecast(location.Latitude, location.Longitude);

      return cityForecast.Response;
    }
  }
}
