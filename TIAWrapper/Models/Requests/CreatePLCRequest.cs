namespace TIAWrapper.Models.Requests;

public class CreatePLCRequest
{
    public string PlcType { get; set; } = "S7-1500";
    public string DeviceName { get; set; } = "PLC_1";
}