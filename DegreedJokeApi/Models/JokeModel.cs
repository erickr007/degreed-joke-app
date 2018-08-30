using System;
using Newtonsoft.Json;

namespace DegreedJokeApi.Models
{
    public class JokeModel
    {
        private string _id;
        private string _joke;

        [JsonProperty(PropertyName = "id")]
        public string Id{
            get { return _id; }
            set { _id = value; }
        }

        [JsonProperty(PropertyName = "joke")]
        public string Joke 
        {
            get { return _joke; }
            set { _joke = value; }
        }
    }
}
