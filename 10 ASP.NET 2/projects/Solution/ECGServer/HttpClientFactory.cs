namespace ECGServer;

public class HttpClientFactory
{
    public static HttpClient CreateHttpClient(string baseUrl)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        return new HttpClient(clientHandler)
        {
            BaseAddress = new Uri(baseUrl)
        };
    }
}