using TIAWrapper.Interfaces;
using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;

namespace TIAWrapper.Services;

public class ProjectService : IProjectService
{
    private readonly ITIAPortalManager _tia;

    public ProjectService(ITIAPortalManager tia)
    {
        _tia = tia;
    }

    public Task<ApiResponse> CreateProjectAsync(CreateProjectRequest request)
    {
        return _tia.CreateProjectAsync(request);
    }

    public Task<ApiResponse> SaveProjectAsync()
    {
        return _tia.SaveProjectAsync();
    }

    public Task<ApiResponse> OpenProjectAsync(string projectPath)
    {
        return _tia.OpenProjectAsync(projectPath);
    }
}