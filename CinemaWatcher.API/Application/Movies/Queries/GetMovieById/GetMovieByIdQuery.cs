using CinemaWatcher.Entities.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Movies.Queries.GetMovieById
{
    public record GetMovieByIdQuery(int Id) : IRequest<Entities.EntitiesModels.Movies>;

    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Entities.EntitiesModels.Movies>
    {
        private readonly MyAppDbContext _context;
        public GetMovieByIdQueryHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Entities.EntitiesModels.Movies> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(x => x.MovieId == request.Id, cancellationToken)
                ?? throw new ArgumentException("Parameter not valid");

            return movie;
        }
    }
}
