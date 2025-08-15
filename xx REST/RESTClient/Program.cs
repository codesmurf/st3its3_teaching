
namespace RESTClient
{
    internal class Program
    {
        private static string apikey = "41bc70d1fe048213997112adbc759840";

        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://api.openweathermap.org")
        };

        static void Main(string[] args)
        {
            using HttpResponseMessage response =
                sharedClient.GetAsync($"/geo/1.0/direct?q=Aarhus&appid={apikey}").Result;

            Console.WriteLine(response);

            var content = response.Content;
            var contentResponse = content.ReadAsStringAsync().Result;
            Console.WriteLine($"{contentResponse}\n");
        }

    }
}
