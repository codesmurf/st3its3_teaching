using System.Text.Json;

namespace WeatherForecast
{
    internal class GeoParser
    {
        // Will recursively look for a "lat" and "lon" pair of fields in a json document.
        public (double? Lat, double? Lon) ExtractLatLon(string json)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    return FindLatLon(doc.RootElement);
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON format.");
                return (null, null);
            }
        }

        private (double? Lat, double? Lon) FindLatLon(JsonElement element)
        {
            // Check if current element has lat and lon
            if (element.ValueKind == JsonValueKind.Object)
            {
                bool hasLat = element.TryGetProperty("lat", out JsonElement latElement);
                bool hasLon = element.TryGetProperty("lon", out JsonElement lonElement);

                if (hasLat && hasLon)
                {
                    return (latElement.GetDouble(), lonElement.GetDouble());
                }

                // Recursively check nested properties
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    var result = FindLatLon(property.Value);
                    if (result.Lat.HasValue && result.Lon.HasValue)
                    {
                        return result;
                    }
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                // Recursively check each item in the array
                foreach (JsonElement item in element.EnumerateArray())
                {
                    var result = FindLatLon(item);
                    if (result.Lat.HasValue && result.Lon.HasValue)
                    {
                        return result;
                    }
                }
            }

            return (null, null);
        }
    }

}
