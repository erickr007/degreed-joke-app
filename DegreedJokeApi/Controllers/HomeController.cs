using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DegreedJokeApi.Models;
using DegreedJokeApi.Services;
using DegreedJokeApi.Services.Interfaces;

namespace DegreedJokeApi.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IJokeService _jokeService;

        public HomeController([FromServices]IJokeService jokeService){
            this._jokeService = jokeService;
        }

        [Route("")]
        [Route("index")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search/{term}")]
        [ResponseCache(VaryByQueryKeys=new string[]{"*"}, Duration=180)]
        public async Task<PartialViewResult> SearchResults([FromRoute]string term){
            var model = await _jokeService.GetJokesSearch(term);

            return PartialView("~/Views/Shared/Partial/_SearchResults.cshtml",model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
