using CinemaWatcher.Entities.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Series.Queries.GetSeries
{
    public record GetSeriesQuery : IRequest<List<Entities.EntitiesModels.Series>>;

    public class GetSeriesQueryHandler : IRequestHandler<GetSeriesQuery, List<Entities.EntitiesModels.Series>>
    {
        private readonly MyAppDbContext _context;
        public GetSeriesQueryHandler(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Entities.EntitiesModels.Series>> Handle(GetSeriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Series.ToListAsync();
        }
    }
}
