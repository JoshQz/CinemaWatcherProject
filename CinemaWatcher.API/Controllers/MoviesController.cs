using CinemaWatcher.API.Application.Movies.Commands.CreateMovie;
using CinemaWatcher.API.Application.Movies.Commands.UpdateMovie;
using CinemaWatcher.API.Application.Movies.Queries.GetMovieById;
using CinemaWatcher.API.Application.Movies.Queries.GetMovies;
using CinemaWatcher.Domain.DataAccess;
using CinemaWatcher.Domain.EntitiesModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWatcher.API.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(MyAppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/movies")]
        public async Task<List<Movies>> GetMovies()
        {
            return await _mediator.Send(new GetMoviesQuery());
        }

        [HttpGet]
        [Route("api/movies/{Id}")]
        public async Task<Movies> GetMovieById(int Id)
        {
            return await _mediator.Send(new GetMovieByIdQuery(Id));
        }

        [HttpPost]
        [Route("api/movies")]
        public async Task<Movies> CreateMovie([FromBody] CreateMovieCommand movie)
        {
            CreateMovieCommand newMovie = new(movie.Title, movie.Category, movie.Duration, movie.DateOfPublish);

            return await _mediator.Send(newMovie);
        }

        [HttpPut]
        [Route("api/movies")]
        public async Task<Movies> UpdateMovie([FromBody] UpdateMovieCommand movie)
        {
            UpdateMovieCommand updateMovie = new(movie.MovieId, movie.Title, movie.Category, movie.Duration, movie.DateOfPublish);
            return await _mediator.Send(updateMovie);
        }
    }
}
