using System.Threading.Tasks;
using DegreedJokeApi.Models;
using DegreedJokeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DegreedJokeApi.API
{
    [Route("api/jokes")]
    public class JokesAPIController : Controller
    {
        private readonly IJokeService _service;

        public JokesAPIController([FromServices]IJokeService service){
            this._service = service;
        }

        [HttpGet]
        public async Task<JokeModel> Get()
        {
            var result = await _service.GetRandomJoke();

            return result;
        }


        [HttpGet("search/{term}")]
        public async Task<JokeResultsModel> Get(string term)
        {
            var result = await _service.GetJokesSearch(term);

            return result;
        }
    }
}
