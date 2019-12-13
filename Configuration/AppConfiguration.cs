using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace WeatherApiTest.Configuration {
  public static class AppConfiguration {
    public static IConfiguration Build() {
      var configurationBuilder = new ConfigurationBuilder();
      configurationBuilder.AddJsonFile("appsettings.json", false, true);
      configurationBuilder.AddUserSecrets(typeof(AppConfiguration).GetTypeInfo().Assembly);

      return configurationBuilder.Build();
    }
  }
}
