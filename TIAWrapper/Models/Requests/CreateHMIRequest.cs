namespace TIAWrapper.Models.Requests;

public class CreateHMIRequest
{
    public string DeviceName { get; set; } = "HMI_1";
    public string HmiType { get; set; } = "Basic";
}