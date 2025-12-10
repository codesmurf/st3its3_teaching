using System.Text.Json;
using WeatherForecast.configuration;
using WeatherForecast.models;

namespace WeatherForecast
{
    internal class Program
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://api.openweathermap.org")
        };

        static void Main(string[] args)
        {
            ProgramConfiguration configuration = ConfigurationManager.Load("../../../configuration.json");

            Console.WriteLine("Enter city name: ");
            string? cityName = Console.ReadLine();
            string? apikey = configuration.OpenWeatherMapApiKey;

            if (cityName != null)
            {
                using HttpResponseMessage response =
                    sharedClient.GetAsync($"/geo/1.0/direct?q={cityName}&appid={apikey}").Result;

                Console.WriteLine(response);

                var content = response.Content;
                var contentResponse = content.ReadAsStringAsync().Result;
                Console.WriteLine($"{contentResponse}\n");

                GeoParser parser = new GeoParser();
                (double? lat, double? lon) = parser.ExtractLatLon(contentResponse);
                Console.WriteLine("Lat: {0} - Lon: {1}", lat, lon);

                using HttpResponseMessage forecastResponse =
                    sharedClient.GetAsync($"/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&appid={apikey}").Result;
                
                content = forecastResponse.Content;
                contentResponse = content.ReadAsStringAsync().Result;
                Console.WriteLine($"{contentResponse}\n");

                if (contentResponse != null)
                {
                    ForecastResponse forecast = JsonSerializer.Deserialize<ForecastResponse>(contentResponse);
                    Console.WriteLine("City: {0}", forecast.City.Name);
                    Console.WriteLine("Country: {0}", forecast.City.Country);
                    foreach (var item in forecast.List)
                    {
                        Console.WriteLine("{0} - Temperature {1}", item.DtTxt, item.Main.Temp);
                    }
                }


            }
            else
            {
                Console.WriteLine("A city name is required to use the program.");
            }
        }
    }
}
