using CinemaWatcher.API.Application.Series.Commands.CreateNewSerie;
using CinemaWatcher.API.Application.Series.Commands.UpdateSerie;
using CinemaWatcher.API.Application.Series.Queries.GetSerieById;
using CinemaWatcher.API.Application.Series.Queries.GetSeries;
using CinemaWatcher.Domain.EntitiesModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWatcher.API.Controllers
{
    public class SeriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SeriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/series")]
        public async Task<List<Series>> GetSeries()
        {
            return await _mediator.Send(new GetSeriesQuery());
        }

        [HttpGet]
        [Route("api/series/{Id}")]
        public async Task<Series> GetSeriesById(int Id)
        {
            return await _mediator.Send(new GetSerieByIdQuery(Id));
        }

        [HttpPost]
        [Route("api/series")]
        public async Task<Series> CreateNewSerie([FromBody] CreateNewSerieCommand newSerie)
        {
            CreateNewSerieCommand createNewSerie = new(
                newSerie.SerieId,
                newSerie.Title,
                newSerie.Category,
                newSerie.Duration,
                newSerie.DateOfPublish);
            return await _mediator.Send(createNewSerie);
        }

        [HttpPut]
        [Route("api/series")]
        public async Task<Series> UpdateSerie([FromBody] UpdateSerieCommand newSerie)
        {
            UpdateSerieCommand updateSerie = new(
                newSerie.SerieId,
                newSerie.Title,
                newSerie.Category,
                newSerie.Duration,
                newSerie.DateOfPublish);
            return await _mediator.Send(updateSerie);
        }
    }
}
