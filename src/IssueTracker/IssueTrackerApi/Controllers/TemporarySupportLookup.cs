

namespace IssueTrackerApi.Controllers;

public class TemporarySupportLookup : ILookupSupportInfo

{
    public async Task<SupportContactResponseModel> GetCurrentSupportInfoAsync()
    {
        return new SupportContactResponseModel
        {
            EMail = "franco@aol.com",
            Phone = "999-9999"
        };
    }
}
