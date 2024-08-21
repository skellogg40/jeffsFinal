
using IssueTrackerApi.TypedClients;

namespace IssueTrackerApi.Controllers;

public class RemoteSupportLookup(SupportApiClient client) : ILookupSupportInfo
{

    public async Task<SupportContactResponseModel> GetCurrentSupportInfoAsync()
    {
        return await client.GetSupportResponseModelAsync();
    }
}
