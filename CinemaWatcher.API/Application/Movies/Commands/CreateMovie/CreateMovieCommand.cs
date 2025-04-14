using CinemaWatcher.Domain.DataAccess;
using MediatR;

namespace CinemaWatcher.API.Application.Movies.Commands.CreateMovie
{
    public record CreateMovieCommand(
        string Title,
        string Category,
        string Duration,
        DateTime DateOfPublish) :
        IRequest<Domain.EntitiesModels.Movies>;

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Domain.EntitiesModels.Movies>
    {
        private readonly MyAppDbContext _context;

        public CreateMovieCommandHandler(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.EntitiesModels.Movies> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            Domain.EntitiesModels.Movies newMovie = new()
            {
                Title = request.Title,
                Category = request.Category,
                Duration = request.Duration,
                DateOfPublish = request.DateOfPublish
            };
            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();
            return newMovie;
        }
    }
}
