using System.Web.Http;
using TIAWrapper.Interfaces;
using TIAWrapper.Managers;
using TIAWrapper.Models.Requests;
using TIAWrapper.Services;

namespace TIAWrapper.Controllers;

[RoutePrefix("api/plc")]
public class PLCController : ApiController
{
    private readonly IPLCService _service;

    public PLCController()
    {
        _service = new PLCService(ServiceContainer.PortalManager);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IHttpActionResult> Create(CreatePLCRequest request)
    {
        var response = await _service.CreatePLCAsync(request);

        return Ok(response);
    }
}