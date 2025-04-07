using CinemaWatcher.Entities.DataAccess;
using MediatR;

namespace CinemaWatcher.API.Application.Series.Commands.CreateNewSerie
{
    public record CreateNewSerieCommand(
        int SerieId,
        string Title,
        string Category,
        string Duration,
        DateTime DateOfPublish
        ) : IRequest<Entities.EntitiesModels.Series>;

    public class CreateNewSerieCommandHandler : IRequestHandler<CreateNewSerieCommand, Entities.EntitiesModels.Series>
    {
        private readonly MyAppDbContext _context;
        public CreateNewSerieCommandHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Entities.EntitiesModels.Series> Handle(CreateNewSerieCommand request, CancellationToken cancellationToken)
        {
            Entities.EntitiesModels.Series newSerie = new()
            {
                Title = request.Title,
                Category = request.Category,
                Duration = request.Duration,
                DateOfPublish = request.DateOfPublish
            };
            _context.Series.Add(newSerie);
            await _context.SaveChangesAsync();
            return newSerie;
        }
    }
}
