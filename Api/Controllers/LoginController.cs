using Api.Dtos;
using Api.Dtos.Requests;
using Api.Dtos.Responses;
using Application.Commands.Authenticate;
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

    [HttpPost]
    [ProducesResponseType(typeof(WsResponse<AuthenticateResponse>), 200)]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request) =>
      Ok(await _mediator.Send(new AuthenticateCommand(request.Email, request.Password)));

  }
}