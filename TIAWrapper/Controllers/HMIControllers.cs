using System.Web.Http;
using TIAWrapper.Interfaces;
using TIAWrapper.Managers;
using TIAWrapper.Models.Requests;
using TIAWrapper.Services;

namespace TIAWrapper.Controllers;

[RoutePrefix("api/hmi")]
public class HMIController : ApiController
{
    private readonly IHMIService _service;

    public HMIController()
    {
        _service = new HMIService(ServiceContainer.PortalManager);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IHttpActionResult> Create(CreateHMIRequest request)
    {
        var response = await _service.CreateHMIAsync(request);

        return Ok(response);
    }
}