using System;
using System.Collections.Generic;
using System.Linq;
using DegreedJokeApi.Services.Interfaces;
using DegreedJokeApi.Models;
using DegreedJokeApi.Models.Configuration;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DegreedJokeApi.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JokeService : IJokeService
    {
        private readonly string _url;

        public JokeService(IOptions<JokeApiSettings> settings){
            this._url = settings.Value.JokeApiUrl;
        }

        public async Task<JokeResultsModel> GetJokesSearch(string term)
        {
            JokeResultsModel resultsModel = new JokeResultsModel();

            using(HttpClient client = new HttpClient()){
                try
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var response = await client.GetAsync(Path.Combine(this._url, $"search?limit=30&term={term}"));
                    string jsonString = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<JokeSearchModel>(jsonString);

                    resultsModel = PackageJokeResults(model.Results);
                }
                catch(Exception e){
                    // log exceptions
                }
            }

            return resultsModel;
        }

        private JokeResultsModel PackageJokeResults(IList<JokeModel> allJokes){
            JokeResultsModel resultsModel = new JokeResultsModel();

            var shortResults = from j in allJokes
                          where j.Joke.Split(' ').Length < 10
                          select j;

            var mediumResults = from j in allJokes
                                where j.Joke.Split(' ').Length < 20  && j.Joke.Split(' ').Length >= 10
                                select j;

            var longResults = from j in allJokes
                              where j.Joke.Split(' ').Length >= 20
                                     select j;

            resultsModel.ShortList = shortResults.ToList<JokeModel>();
            resultsModel.MediumList = mediumResults.ToList<JokeModel>();
            resultsModel.LongList = longResults.ToList<JokeModel>();

            return resultsModel;
        }

        public async Task<JokeModel> GetRandomJoke()
        {
            JokeModel joke = new JokeModel();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var response = await client.GetAsync(this._url);
                    string jsonString = await response.Content.ReadAsStringAsync();

                    joke = JsonConvert.DeserializeObject<JokeModel>(jsonString);
                }
                catch (Exception e)
                {
                    // log exceptions
                }
            }

            return joke;
        }
    }
}
