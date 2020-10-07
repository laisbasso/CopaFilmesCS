using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmesAPI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CopaFilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<FilmeModel> filmes { get; set; }

        // construtor
        public FilmeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // funciona!!!!!! não retorna mais a pág inteira, só os dados
        [HttpGet]
        public async Task<IEnumerable<FilmeModel>> GetAllFilmes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "http://copafilmes.azurewebsites.net/api/filmes");

            var client = _clientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                filmes = await JsonSerializer.DeserializeAsync
                    <IEnumerable<FilmeModel>>(responseStream);
            }
            else
            {
                // aqui é o erro, melhorar depois
                filmes = new List<FilmeModel>();
            }

            return filmes;

        }

    }
}