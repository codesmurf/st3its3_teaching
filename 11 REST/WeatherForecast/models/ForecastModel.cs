using System.Text.Json.Serialization;

namespace WeatherForecast.models
{
    public class ForecastResponse
    {
        [JsonPropertyName("cod")]
        /// Internal parameter representing server response code (e.g., "200").
        public string? Cod { get; set; }

        [JsonPropertyName("message")]
        /// Internal parameter; typically always 0.
        public int Message { get; set; }

        [JsonPropertyName("cnt")]
        /// Number of 3-hour forecast entries returned.
        public int Cnt { get; set; }

        [JsonPropertyName("list")]
        /// List of forecast items, each covering a 3-hour interval.
        public List<ForecastItem>? List { get; set; }

        [JsonPropertyName("city")]
        /// Information about the requested city or location.
        public CityInfo? City { get; set; }
    }

    public class ForecastItem
    {
        [JsonPropertyName("dt")]
        /// Time of data forecast, Unix timestamp (UTC).
        public long? Dt { get; set; }

        [JsonPropertyName("dt_txt")]
        /// Human-readable time of forecast, formatted as "YYYY-MM-DD HH:mm:ss".
        public string? DtTxt { get; set; }

        [JsonIgnore]
        /// Computed convenience property converting 'dt' to DateTime.
        public DateTime? Date => Dt.HasValue
            ? DateTimeOffset.FromUnixTimeSeconds(Dt.Value).DateTime
            : null;

        [JsonPropertyName("main")]
        /// Main weather measurements (temp, pressure, humidity, etc.).
        public MainInfo? Main { get; set; }

        [JsonPropertyName("weather")]
        /// Array with weather condition info; includes `main`, `description`, `icon`, etc.
        public List<WeatherInfo>? Weather { get; set; }

        [JsonPropertyName("clouds")]
        /// Cloudiness information—percentage of sky covered.
        public Clouds? Clouds { get; set; }

        [JsonPropertyName("wind")]
        /// Wind data: speed, direction, gust [2](https://openweathermap.org/current).
        public Wind? Wind { get; set; }

        [JsonPropertyName("visibility")]
        /// Visibility, meters—less if obscured [2](https://openweathermap.org/current).
        public int? Visibility { get; set; }

        [JsonPropertyName("pop")]
        /// Probability of precipitation (0–1).
        public double? Pop { get; set; }

        [JsonPropertyName("rain")]
        /// Rain volume for the last 3 hours, in mm.
        public Rain? Rain { get; set; }

        [JsonPropertyName("sys")]
        /// Contains `pod`: "p" = day, "n" = night [5](https://stackoverflow.com/questions/67131224/fetching-openweather-forecast-using-javascript).
        public Sys? Sys { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double? Temp { get; set; }

        [JsonPropertyName("feels_like")]
        /// Human perception of temperature.
        public double? Feels_Like { get; set; }

        [JsonPropertyName("temp_min")]
        /// Minimum temperature within the large urban area.
        public double? Temp_Min { get; set; }

        [JsonPropertyName("temp_max")]
        /// Maximum temperature within the large urban area.
        public double? Temp_Max { get; set; }

        [JsonPropertyName("pressure")]
        /// Atmospheric pressure at sea level (hPa).
        public int? Pressure { get; set; }

        [JsonPropertyName("sea_level")]
        /// Atmospheric pressure at sea level (hPa).
        public int? Sea_Level { get; set; }

        [JsonPropertyName("grnd_level")]
        /// Atmospheric pressure on the ground level (hPa).
        public int? Grnd_Level { get; set; }

        [JsonPropertyName("humidity")]
        /// Humidity percentage.
        public int? Humidity { get; set; }

        [JsonPropertyName("temp_kf")]
        /// Internal adjustment factor — use case-specific.
        public double? Temp_Kf { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("main")]
        /// Group of weather parameters (Rain, Snow, Clouds).
        public string? Main { get; set; }

        [JsonPropertyName("description")]
        /// Weather condition within the group (e.g., "light rain").
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        /// Code for weather icon to display.
        public string? Icon { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        /// Sky cloudiness in percent.
        public int? All { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        /// Wind speed. Units: meter/sec, or miles/hour if imperial.
        public double? Speed { get; set; }

        [JsonPropertyName("deg")]
        /// Wind direction in degrees (meteorological).
        public int? Deg { get; set; }

        [JsonPropertyName("gust")]
        /// Wind gust speed. [2](https://openweathermap.org/current)
        public double? Gust { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("3h")]
        /// Rain volume for last 3 hours, mm (present only if rain occurred).
        public double? ThreeH { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("pod")]
        /// Part of day: `"n"` = night, `"d"` = day [5](https://stackoverflow.com/questions/67131224/fetching-openweather-forecast-using-javascript).
        public string? Pod { get; set; }
    }

    public class CityInfo
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        /// City name.
        public string? Name { get; set; }

        [JsonPropertyName("coord")]
        /// Geographic coordinates (latitude, longitude).
        public Coord? Coord { get; set; }

        [JsonPropertyName("country")]
        /// ISO country code (e.g., "GB").
        public string? Country { get; set; }

        [JsonPropertyName("population")]
        /// City population.
        public int? Population { get; set; }

        [JsonPropertyName("timezone")]
        /// Shift in seconds from UTC for the location.
        public int? Timezone { get; set; }

        [JsonPropertyName("sunrise")]
        /// Sunrise time, Unix timestamp (UTC).
        public long? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        /// Sunset time, Unix timestamp (UTC).
        public long? Sunset { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lat")]
        /// City latitude.
        public double? Lat { get; set; }

        [JsonPropertyName("lon")]
        /// City longitude.
        public double? Lon { get; set; }
    }
}
