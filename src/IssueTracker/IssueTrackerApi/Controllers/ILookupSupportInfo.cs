namespace IssueTrackerApi.Controllers;

public interface ILookupSupportInfo
{
    Task<SupportContactResponseModel> GetCurrentSupportInfoAsync();
}