using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Interfaces;

public interface IProjectService
{
    Task<ApiResponse> CreateProjectAsync(CreateProjectRequest request);
    Task<ApiResponse> SaveProjectAsync();
    Task<ApiResponse> OpenProjectAsync(string projectPath);
}