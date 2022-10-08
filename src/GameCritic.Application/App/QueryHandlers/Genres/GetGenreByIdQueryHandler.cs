using MediatR;
using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Dtos.Genre;
using GameCritic.Application.App.Queries.Genres;
using GameCritic.Application.Common.Exceptions;

namespace GameCritic.Application.App.QueryHandlers.Genres
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.GenreRepository.GetGenre(p => request.GenreId == p.Id);

            if (genre == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No genre found");

            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }
    }
}
