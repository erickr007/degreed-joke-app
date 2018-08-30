using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DegreedJokeApi.Models
{
    public class JokeResultsModel
    {

        List<JokeModel> _shortList;
        List<JokeModel> _mediumList;
        List<JokeModel> _longList;

        [JsonProperty("short")]
        public List<JokeModel> ShortList{
            get { return _shortList; }
            set { _shortList = value; }
        }

        [JsonProperty("medium")]
        public List<JokeModel> MediumList{
            get { return _mediumList; }
            set { _mediumList = value; }
        }

        [JsonProperty("long")]
        public List<JokeModel> LongList{
            get { return _longList; }
            set { _longList = value; }
        }

        public JokeResultsModel()
        {
            this._shortList = new List<JokeModel>();
            this._mediumList = new List<JokeModel>();
            this._longList = new List<JokeModel>();
        }
    }
}
