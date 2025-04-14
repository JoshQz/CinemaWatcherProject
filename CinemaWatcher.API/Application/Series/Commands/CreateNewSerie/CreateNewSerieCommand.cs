using CinemaWatcher.Domain.DataAccess;
using MediatR;

namespace CinemaWatcher.API.Application.Series.Commands.CreateNewSerie
{
    public record CreateNewSerieCommand(
        int SerieId,
        string Title,
        string Category,
        string Duration,
        DateTime DateOfPublish
        ) : IRequest<Domain.EntitiesModels.Series>;

    public class CreateNewSerieCommandHandler : IRequestHandler<CreateNewSerieCommand, Domain.EntitiesModels.Series>
    {
        private readonly MyAppDbContext _context;
        public CreateNewSerieCommandHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.EntitiesModels.Series> Handle(CreateNewSerieCommand request, CancellationToken cancellationToken)
        {
            Domain.EntitiesModels.Series newSerie = new()
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
