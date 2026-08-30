using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Interfaces;

public interface IHMIService
{
    Task<ApiResponse> CreateHMIAsync(CreateHMIRequest request);
}