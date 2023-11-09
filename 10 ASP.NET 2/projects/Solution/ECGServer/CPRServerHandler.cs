using System.Net.Http.Json;
using ECGServer.Data;

namespace ECGServer;

public class CPRServerHandler
{
    private HttpClient _httpClient;
    private string baseURL;
    public CPRServerHandler(string baseURL)
    {
        _httpClient = HttpClientFactory.CreateHttpClient(baseURL);
        this.baseURL = baseURL;
    }

    public Task<Patient> GetPatient(string cpr)
    {
        return _httpClient.GetFromJsonAsync<Patient>(cpr);
    }
}