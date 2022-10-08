using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.App.Commands.Publishers;

namespace GameCritic.Application.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Publisher, PublisherListDto>();
            CreateMap<CreatePublisherCommand, Publisher>();
            CreateMap<UpdatePublisherCommand, Publisher>();
        }
    }
}
