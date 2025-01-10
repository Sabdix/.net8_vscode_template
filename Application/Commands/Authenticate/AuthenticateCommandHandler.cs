using Api.Dtos;
using Api.Dtos.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Authenticate
{
  public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, WsResponse<AuthenticateResponse>>
  {
    private readonly IGenericRepository<Client> _clientRepository;
    private readonly IMapper _mapper;

    public AuthenticateCommandHandler(IGenericRepository<Client> repository, IMapper mapper)
    {
      _clientRepository = repository;
      _mapper = mapper;
    }

    public async Task<WsResponse<AuthenticateResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
      var client = await _clientRepository.FindOneAsync(x => x.Email == request.Email);
      return WsResponse<AuthenticateResponse>.BuildOkResponse(new AuthenticateResponse("token", _mapper.Map<ClientDto>(client)));
    }
  }
}