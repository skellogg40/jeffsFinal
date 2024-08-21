using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace IssueTrackerApi.Controllers;

// GET /status
public class StatusController : ControllerBase
{
    private ILookupSupportInfo supportLookup;
    // Udi Dahan - 

    public StatusController(ILookupSupportInfo supportLookup)
    {
        this.supportLookup = supportLookup;

    }

    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatus()
    {
        // do some work here -


        var response = new StatusResponseModel
        {
            Message = "Looks Good Here, Boss!",
            SupportInfoLink = "/status/support"

        };
        return Ok(response);
    }

    [HttpGet("/status/support")]
    [OutputCache(Duration = 3600)]
    public async Task<ActionResult> GetSupportInfo()
    {
        SupportContactResponseModel supportInfo = await supportLookup.GetCurrentSupportInfoAsync();
        return Ok(supportInfo);
    }
}


public record StatusResponseModel
{
    public string Message { get; set; } = string.Empty;

    public string SupportInfoLink { get; set; } = string.Empty;

}
