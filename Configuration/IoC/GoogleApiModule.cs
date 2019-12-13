using Autofac;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using Microsoft.Extensions.Options;

namespace WeatherApiTest.Configuration.IoC {
  public class GoogleApiModule : Module {
    protected override void Load(ContainerBuilder builder) {
      builder.Register(c => {
        var googleApiOptions = c.Resolve<IOptions<GoogleApiOptions>>();

        return new AddressGeocodeRequest {Key = googleApiOptions.Value.ApiKey};
      });
    }
  }
}
