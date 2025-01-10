using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Api.Profiles
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<Client, ClientDto>().ReverseMap();
    }
  }
}