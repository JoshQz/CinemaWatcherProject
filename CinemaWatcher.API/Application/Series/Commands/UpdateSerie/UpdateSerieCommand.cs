using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Series.Commands.UpdateSerie
{
    public record UpdateSerieCommand(
        int SerieId,
        string Title,
        string Category,
        string Duration,
        DateTime DateOfPublish
        ) : IRequest<Entities.EntitiesModels.Series>;

    public class UpdateSerieCommandHandler : IRequestHandler<UpdateSerieCommand, Entities.EntitiesModels.Series>
    {
        private readonly Entities.DataAccess.MyAppDbContext _context;
        public UpdateSerieCommandHandler(Entities.DataAccess.MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.EntitiesModels.Series> Handle(UpdateSerieCommand request, CancellationToken cancellationToken)
        {
            Entities.EntitiesModels.Series serie = await _context.Series
                .FirstOrDefaultAsync(x => x.SerieId == request.SerieId, cancellationToken)
                ?? throw new Exception("Serie not found");

            serie.Title = request.Title;
            serie.Category = request.Category;
            serie.Duration = request.Duration;
            serie.DateOfPublish = request.DateOfPublish;

            await _context.SaveChangesAsync();
            return serie;
        }
    }
}
