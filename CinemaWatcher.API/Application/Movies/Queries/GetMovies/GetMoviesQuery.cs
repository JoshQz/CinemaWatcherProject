using CinemaWatcher.Domain.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Movies.Queries.GetMovies
{
    public record GetMoviesQuery() : IRequest<List<Domain.EntitiesModels.Movies>>;

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<Domain.EntitiesModels.Movies>>
    {
        private readonly MyAppDbContext _context;
        public GetMoviesQueryHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.EntitiesModels.Movies>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Movies.ToListAsync();
        }
    }
}
