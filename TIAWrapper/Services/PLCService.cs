using TIAWrapper.Interfaces;
using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Services;

public class PLCService : IPLCService
{
    private readonly ITIAPortalManager _tia;

    public PLCService(ITIAPortalManager tia)
    {
        _tia = tia;
    }

    public Task<ApiResponse> CreatePLCAsync(CreatePLCRequest request)
    {
        return _tia.CreatePLCAsync(request);
    }
}