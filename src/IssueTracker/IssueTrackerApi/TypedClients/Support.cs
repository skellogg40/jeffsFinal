namespace IssueTrackerApi.TypedClients;

public class SupportApiClient
{
    // The thing that knows how to call Franco's support API.
    private HttpClient _httpClient;

    public SupportApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SupportContactResponseModel?> GetSupportResponseModelAsync()
    {
        var response = await _httpClient.GetAsync("/support-info");
        response.EnsureSuccessStatusCode(); // If the response isn't a 200-299, BLOW UP HERE.

        var representation = await response.Content.ReadFromJsonAsync<SupportContactResponseModel>();

        return representation;
    }
}
