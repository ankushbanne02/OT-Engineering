using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Interfaces;

public interface IPLCService
{
    Task<ApiResponse> CreatePLCAsync(CreatePLCRequest request);
}