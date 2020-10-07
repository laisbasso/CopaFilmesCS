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
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("ano")]
        public int Ano { get; set; }

        [JsonPropertyName("nota")]
        public decimal Nota { get; set; }
    }


}
