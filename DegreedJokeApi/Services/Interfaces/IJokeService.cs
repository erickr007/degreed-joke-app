using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DegreedJokeApi.Models;

namespace DegreedJokeApi.Services.Interfaces
{
    public interface IJokeService
    {

        Task<JokeModel> GetRandomJoke();
        Task<JokeResultsModel> GetJokesSearch(string term);

    }
}
