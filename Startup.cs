using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Variance;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherApiTest.Configuration;

namespace WeatherApiTest {
  public class Startup {
    private IConfiguration _configuration { get; }

    public Startup(IConfiguration configuration) {
      _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddOptions();
      services.Configure<DarkSkyOptions>(_configuration.GetSection("DarkSky"));
      services.Configure<GoogleApiOptions>(_configuration.GetSection("GoogleApi"));
      
      services.AddMediatR(Assembly.GetExecutingAssembly());
      
      services.AddControllers();
    }

    public void ConfigureContainer(ContainerBuilder builder) {
      builder.RegisterSource(new ContravariantRegistrationSource());

      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}
