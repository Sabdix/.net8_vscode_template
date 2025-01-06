using Api.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("api/login")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [Route("ping")]
    [ProducesResponseType(typeof(WsResponse<string>), 200)]
    public IActionResult Ping()
    {
      return Ok(WsResponse<string?>.BuildOkResponse(null));
    }
  }
}