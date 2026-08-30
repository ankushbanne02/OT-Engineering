using TIAWrapper.Models.Responses;
namespace TIAWrapper.Interfaces;

public interface IConnectionService
{
    Task<ApiResponse> ConnectAsync();
    Task<ApiResponse> DisconnectAsync();
    bool IsConnected();
}