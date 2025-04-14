
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.API.Application.Series.Queries.GetSerieById
{
    public record GetSerieByIdQuery(int Id) : IRequest<Domain.EntitiesModels.Series>;

    public class GetSerieByIdQueryHandler : IRequestHandler<GetSerieByIdQuery, Domain.EntitiesModels.Series>
    {
        private readonly Domain.DataAccess.MyAppDbContext _context;
        public GetSerieByIdQueryHandler(Domain.DataAccess.MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.EntitiesModels.Series> Handle(GetSerieByIdQuery request, CancellationToken cancellationToken)
        {
            var serie = await _context.Series
                .FirstOrDefaultAsync(x => x.SerieId == request.Id, cancellationToken)
                ?? throw new ArgumentException("Parameter not valid");
            return serie;
        }
    }
}
