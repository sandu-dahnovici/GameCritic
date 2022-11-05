using AutoMapper;
using GameCritic.Application.App.Queries.Genres;
using GameCritic.Application.Common.Dtos.Genre;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Publishers
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IList<GenreListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGenresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GenreListDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = _unitOfWork.GenreRepository.GetAll();

            if (genres == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NoContent, "No genres available");

            List<GenreListDto> genreListDtos = new();
            foreach (var publisher in genres)
            {
                genreListDtos.Add(_mapper.Map<GenreListDto>(publisher));
            }

            return genreListDtos;
        }
    }
}
