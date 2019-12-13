# Weather API Test
This repository tests the feasibility of utilizing DarkSky API and Google Geocoding API together to determine accurate weather data given a city and state.

### Setup
Requires .NET Core 3.1 and the ASP.NET Core runtime which can be found [here](https://dotnet.microsoft.com/download).

Sign up for a [DarkSky API key](https://darksky.net/dev) and follow [this guide](https://developers.google.com/maps/documentation/geocoding/get-api-key) to get a Google Geolocation API key.

Clone this repository from git:
```bash
git clone https://github.com/ryanseipp/WeatherApiTest.git
```

Add API keys as dotnet user-secrets
```bash
dotnet user-secrets set GoogleApi:ApiKey <Your Google API key here>
dotnet user-secrets set DarkSky:ApiKey <Your DarkSky API key here>
```

Run the project and test using an HTTP client like Postman or curl/wget
```bash
dotnet run

// returns current weather information on Alcatraz Island
curl http://localhost:5000/WeatherForecast

// returns current weather information for Pittsburgh, PA. Adapt as you see fit.
curl http://localhost:5000/WeatherForecast/City?City="Pittsburgh"&State="PA"
```

### Projects used within this proof of concept
* [DarkSkyCore](https://github.com/amweiss/dark-sky-core)
* [GoogleApi](https://github.com/vivet/GoogleApi)

### Things to improve upon
We need to be able to inject our GoogleApi and DarkSky API keys before using them. This is currently done through Autofac DI, but doesn't feel great. Need to find a better solution to either isolate key injection from user-secrets/configuration, or create/discover a more robust DI solution for GoogleApi that supports key injection.
