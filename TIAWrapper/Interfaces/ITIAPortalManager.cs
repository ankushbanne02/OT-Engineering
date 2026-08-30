using TIAWrapper.Models.Responses;
using TIAWrapper.Models.Requests;

namespace TIAWrapper.Interfaces;

public interface ITIAPortalManager
{
    Task<ApiResponse> ConnectAsync();
    Task<ApiResponse> DisconnectAsync();
    Task<ApiResponse> CreateProjectAsync(CreateProjectRequest request);
    Task<ApiResponse> SaveProjectAsync();
    Task<ApiResponse> OpenProjectAsync(string projectPath);
    Task<ApiResponse> CreatePLCAsync(CreatePLCRequest request);
    Task<ApiResponse> CreateHMIAsync(CreateHMIRequest request);
    bool IsConnected();
}