using Autofac;
using DarkSky.Services;
using Microsoft.Extensions.Options;

namespace WeatherApiTest.Configuration.IoC {
  public class WeatherModule : Module {
    protected override void Load(ContainerBuilder builder) {
      builder.Register(c => {
        var darkSkyOptions = c.Resolve<IOptions<DarkSkyOptions>>();

        return new DarkSkyService(darkSkyOptions.Value.ApiKey);
      });
    }
  }
}
