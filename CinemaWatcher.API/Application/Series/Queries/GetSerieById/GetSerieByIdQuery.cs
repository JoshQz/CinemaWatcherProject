
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Series.Queries.GetSerieById
{
    public record GetSerieByIdQuery(int Id) : IRequest<Entities.EntitiesModels.Series>;

    public class GetSerieByIdQueryHandler : IRequestHandler<GetSerieByIdQuery, Entities.EntitiesModels.Series>
    {
        private readonly Entities.DataAccess.MyAppDbContext _context;
        public GetSerieByIdQueryHandler(Entities.DataAccess.MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Entities.EntitiesModels.Series> Handle(GetSerieByIdQuery request, CancellationToken cancellationToken)
        {
            var serie = await _context.Series
                .FirstOrDefaultAsync(x => x.SerieId == request.Id, cancellationToken)
                ?? throw new ArgumentException("Parameter not valid");
            return serie;
        }
    }
}
