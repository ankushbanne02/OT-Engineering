namespace TIAWrapper.Models.Requests;

public class CreateProjectRequest
{
    public string ProjectName { get; set; } = string.Empty;
    public string Directory { get; set; } = string.Empty;
}