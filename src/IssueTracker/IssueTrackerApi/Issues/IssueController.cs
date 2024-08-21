using Marten;
using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Issues;

public class IssueController(IDocumentSession session) : ControllerBase
{

    [HttpPost("/issues")]
    public async Task<ActionResult> AddIssueAsync([FromBody] IssueCreateRequestModel request)
    {
        // TODO: Validate the  request 

        var response = new IssueCreateResponseModel
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Impact = request.Impact,
            Software = request.Software,
            Status = "PendingAssignment"
        };
        // TODO: Save it to a database
        session.Store(response);
        await session.SaveChangesAsync();
        return Ok(response);
    }

    [HttpGet("/issues")]
    public async Task<ActionResult> GetAllIssues()
    {
        var data = await session.Query<IssueCreateResponseModel>().ToListAsync();
        return Ok(new { issues = data });
    }
}

public record IssueCreateRequestModel
{
    public string Software { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Impact { get; set; } = string.Empty;

}


public record IssueCreateResponseModel
{
    public Guid Id { get; set; }
    public string Software { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Impact { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}

/*{
  "Software": "vscode",
  "description": "Won't Update",
  "impact": "Inconvenience"
  
}*/