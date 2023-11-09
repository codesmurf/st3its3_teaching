using System.Net;
using System.Net.Http.Json;
using ECGServer.Data;

namespace ECGServer;

internal class EcgServerHandler
{
    private HttpClient _httpClient;

    public EcgServerHandler(string baseURL)
    {
        _httpClient = HttpClientFactory.CreateHttpClient(baseURL);
    }

    public async Task<HttpStatusCode> AddPerson(Patient patient)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/person/add", patient);
        return httpResponse.StatusCode;
    }

    public async Task<HttpStatusCode> AddSummary(SnapShot snapShot)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/ekg/summary", snapShot);
        return httpResponse.StatusCode;
    }
}