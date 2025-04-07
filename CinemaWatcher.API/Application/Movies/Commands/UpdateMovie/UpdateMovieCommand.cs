using CinemaWatcher.Entities.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Movies.Commands.UpdateMovie
{
    public record UpdateMovieCommand(
        int MovieId,
        string Title,
        string Category,
        string Duration,
        DateTime DateOfPublish) : IRequest<Entities.EntitiesModels.Movies>;

    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Entities.EntitiesModels.Movies>
    {
        private readonly MyAppDbContext _context;
        public UpdateMovieCommandHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Entities.EntitiesModels.Movies> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            Entities.EntitiesModels.Movies movie = await _context.Movies
                .FirstOrDefaultAsync(x => x.MovieId == request.MovieId, cancellationToken)
                ?? throw new Exception("Movie not found");

            movie.Title = request.Title;
            movie.Category = request.Category;
            movie.Duration = request.Duration;
            movie.DateOfPublish = request.DateOfPublish;
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
