namespace IssueTracker.Shared;


public record SupportContactResponseModel
{
    public string EMail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}