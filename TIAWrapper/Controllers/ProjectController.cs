using System.Web.Http;
using TIAWrapper.Interfaces;
using TIAWrapper.Managers;
using TIAWrapper.Models.Requests;
using TIAWrapper.Services;

namespace TIAWrapper.Controllers;

[RoutePrefix("api/project")]
public class ProjectController : ApiController
{
    private readonly IProjectService _service;

    public ProjectController()
    {
        _service = new ProjectService(ServiceContainer.PortalManager);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IHttpActionResult> CreateProject(CreateProjectRequest request)
    {
        return Ok(await _service.CreateProjectAsync(request));
    }

    [HttpPost]
    [Route("save")]
    public async Task<IHttpActionResult> SaveProject()
    {
        return Ok(await _service.SaveProjectAsync());
    }

    [HttpPost]
    [Route("open")]
    public async Task<IHttpActionResult> OpenProject([FromUri] string path)
    {
        return Ok(await _service.OpenProjectAsync(path));
    }
}