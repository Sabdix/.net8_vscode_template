using Api.Dtos;
using Api.Dtos.Responses;
using MediatR;

namespace Application.Commands.Authenticate
{
  public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, WsResponse<AuthenticateResponse>>
  {
    public Task<WsResponse<AuthenticateResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(WsResponse<AuthenticateResponse>.BuildOkResponse(new AuthenticateResponse("token")));
    }
  }
}