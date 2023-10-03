using AutoMapper;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Contracts.Authentication;

namespace DinnerBooking.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRequest, RegisterRequestDto>().ReverseMap();
            CreateMap<LoginRequest, LoginRequestDto>().ReverseMap();
        }
    }
}