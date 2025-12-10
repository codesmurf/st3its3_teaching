using System.Text.Json;

namespace WeatherForecast.configuration
{
    internal class ConfigurationManager
    {
        public static void Save(string path, ProgramConfiguration configuration)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(configuration);
                File.WriteAllText(path, jsonString);
            }
            catch ( Exception e )
            {
                Console.WriteLine("Failed to save configuration.");
                Console.WriteLine(e.ToString());
                Environment.Exit(1);
            }
        }

        public static ProgramConfiguration Load(string path)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                ProgramConfiguration configuration = JsonSerializer.Deserialize<ProgramConfiguration>(jsonString);
                return configuration;
            }
            catch ( Exception e )
            {
                Console.WriteLine("Failed to load configuration.");
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine("Writing default configuration file at " + path + ".default");
                Console.WriteLine("edit it and rename to " + path);
                
                ProgramConfiguration defaultConfig = new ProgramConfiguration();
                defaultConfig.OpenWeatherMapApiKey = "place_your_api_key_here";
                Save(path + ".default", defaultConfig);
                Environment.Exit(1);

                throw; // the compiler does not know, that the program exits in the "Exit" statement
            }
        }
    }
}
