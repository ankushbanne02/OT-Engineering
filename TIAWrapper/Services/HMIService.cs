using TIAWrapper.Interfaces;
using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Services;

public class HMIService : IHMIService
{
    private readonly ITIAPortalManager _tia;

    public HMIService(ITIAPortalManager tia)
    {
        _tia = tia;
    }

    public Task<ApiResponse> CreateHMIAsync(CreateHMIRequest request)
    {
        return _tia.CreateHMIAsync(request);
    }
}