using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DegreedJokeApi.Models
{
    public class JokeSearchModel
    {
        private int _currentPage;
        private int _limit;
        private int _nextPage;
        private int _previousPage;
        private IList<JokeModel> _results;
        private string _searchTerm;
        private int _status;
        private int _totalJokes;
        private int _totalPages;

        [JsonProperty("current_page")]
        public int CurrentPage{
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        [JsonProperty("limit")]
        public int Limit{
            get { return _limit; }
            set { _limit = value; }
        }

        [JsonProperty("next_page")]
        public int NextPage{
            get { return _nextPage; }
            set { _nextPage = value; }
        }
        [JsonProperty("previous_page")]
        public int PreviousPage{
            get { return _previousPage; }
            set { _previousPage = value; }
        }

        [JsonProperty("results")]
        public IList<JokeModel> Results{
            get { return _results; }
            set { _results = value; }
        }

        [JsonProperty("search_term")]
        public string SearchTerm{
            get { return _searchTerm; }
            set { _searchTerm = value; }
        }

        [JsonProperty("status")]
        public int Status{
            get { return _status; }
            set { _status = value; }
        }

        [JsonProperty("total_jokes")]
        public int TotalJokes{
            get { return _totalJokes; }
            set { _totalJokes = value; }
        }

        [JsonProperty("total_pages")]
        public int TotalPages{
            get { return _totalPages; }
            set { _totalPages = value; }
        }
    }
}
