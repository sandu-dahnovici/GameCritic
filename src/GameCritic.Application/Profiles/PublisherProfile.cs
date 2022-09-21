using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.App.Dtos.Publisher;

namespace GameCritic.Application.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>();
        }
    }
}
