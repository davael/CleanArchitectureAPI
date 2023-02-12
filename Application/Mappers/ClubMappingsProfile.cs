using Application.Dtos.Request;
using Application.Dtos.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class ClubMappingsProfile : Profile
    {
        public ClubMappingsProfile()
        {
            CreateMap<Club, ClubResponseDto>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<Club>, BaseEntityResponse<ClubResponseDto>>()
                .ReverseMap();
            CreateMap<ClubRequestDto, Club>();
            CreateMap<Club, ClubSelectResponseDto>()
                .ReverseMap();

        }
    }
}
