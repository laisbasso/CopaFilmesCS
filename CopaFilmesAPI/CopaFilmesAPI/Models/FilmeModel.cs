using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Models
{
    public class FilmeModel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("titulo")]
        public string titulo { get; set; }

        [JsonProperty("ano")]
        public int ano { get; set; }

        [JsonProperty("nota")]
        public decimal nota { get; set; }
    }
}
