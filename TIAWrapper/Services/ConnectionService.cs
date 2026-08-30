using TIAWrapper.Interfaces;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Services;

public class ConnectionService : IConnectionService
{
    private readonly ITIAPortalManager _tiaManager;

    public ConnectionService(ITIAPortalManager tiaManager)
    {
        _tiaManager = tiaManager;
    }

    public Task<ApiResponse> ConnectAsync()
    {
        return _tiaManager.ConnectAsync();
    }

    public Task<ApiResponse> DisconnectAsync()
    {
        return _tiaManager.DisconnectAsync();
    }

    public bool IsConnected()
    {
        return _tiaManager.IsConnected();
    }
}