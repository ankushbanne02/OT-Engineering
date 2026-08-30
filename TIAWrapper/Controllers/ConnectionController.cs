using System.Web.Http;
using TIAWrapper.Interfaces;
using TIAWrapper.Managers;
using TIAWrapper.Services;

namespace TIAWrapper.Controllers;

[RoutePrefix("api/connection")]

public class ConnectionController : ApiController
{
    private readonly IConnectionService _service;

    public ConnectionController()
    {
        _service = new ConnectionService(ServiceContainer.PortalManager);
    }
    [HttpPost]
    [Route("connect")]

    public async Task<IHttpActionResult> Connect()
    {
        return Ok(
            await _service.ConnectAsync()
        );
    }

    [HttpPost]
    [Route("disconnect")]
    public async Task<IHttpActionResult> Disconnect()
    {
        return Ok(
            await _service.DisconnectAsync()
        );
    }

    [HttpGet]
    [Route("status")]
    public IHttpActionResult Status()
    {
        return Ok(
            _service.IsConnected()
        );
    }
}