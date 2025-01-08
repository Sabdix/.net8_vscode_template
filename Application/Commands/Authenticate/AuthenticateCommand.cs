using Api.Dtos;
using Api.Dtos.Responses;
using MediatR;

namespace Application.Commands.Authenticate
{
  public record AuthenticateCommand(string Email, string Password) : IRequest<WsResponse<AuthenticateResponse>>;
}
