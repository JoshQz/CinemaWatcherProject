using CinemaWatcher.Domain.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Movies.Queries.GetMovieById
{
    public record GetMovieByIdQuery(int Id) : IRequest<Domain.EntitiesModels.Movies>;

    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Domain.EntitiesModels.Movies>
    {
        private readonly MyAppDbContext _context;
        public GetMovieByIdQueryHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.EntitiesModels.Movies> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(x => x.MovieId == request.Id, cancellationToken)
                ?? throw new ArgumentException("Parameter not valid");

            return movie;
        }
    }
}
