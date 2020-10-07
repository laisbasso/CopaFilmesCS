using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmesAPI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Linq;

namespace CopaFilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<FilmeModel> ListaIEnumerable { get; set; }
        public List<FilmeModel> ListaFilmes { get; set; }

        // construtor
        public FilmeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // funciona!!!!!! não retorna mais a pág inteira, só os dados
        [HttpGet]
        public async Task<List<FilmeModel>> GetAllFilmes()
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
                ListaIEnumerable = await JsonSerializer.DeserializeAsync
                    <IEnumerable<FilmeModel>>(responseStream);

                ListaFilmes = ListaIEnumerable.ToList();
            }
            else
            {
                // aqui é o erro, melhorar depois
                ListaFilmes = new List<FilmeModel>();
            }

            return ListaFilmes;

        }

        public List<FilmeModel> gerarOrdemAlfabetica(List<FilmeModel> ListaFilmes)
        {
            ListaFilmes.Sort((x, y) => string.Compare(x.Titulo, y.Titulo));

            return ListaFilmes;

        }

        [HttpPost]
        public List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes)
        {
            gerarOrdemAlfabetica(ListaFilmes);

            return ListaFilmes;

        }






     }
}