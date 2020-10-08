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

        List<FilmeModel> FilmesVencedores = new List<FilmeModel>();

        public List<FilmeModel> faseEliminatoria(List<FilmeModel> ListaFilmes)
        {
            // já recebo a lista ordenada

            int posicaoB = ListaFilmes.Count-1;

            // limpa a lista porque faz a verificação duas vezes
            // hmm acho que não vai dar certo kk
            // FilmesVencedores.Clear();

            for (int posicaoA = 0; posicaoA < posicaoB; posicaoA++)
            {
               int posicaoVencedora = ListaFilmes[posicaoA].Nota > ListaFilmes[posicaoB].Nota ?
                    posicaoA : posicaoB;

                FilmesVencedores.Add(ListaFilmes[posicaoVencedora]);
                posicaoB--;
            }

            // verificação da lista final
            if (FilmesVencedores.Count == 2)
            {
                if (FilmesVencedores[0].Nota < ListaFilmes[posicaoB].Nota)
                {
                    FilmeModel trocarElemento = FilmesVencedores[0];
                    FilmesVencedores[0] = FilmesVencedores[1];
                    FilmesVencedores[1] = trocarElemento;
                }
            }

            return FilmesVencedores;

        }

        [HttpPost]
        public List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes)
        {
            List<FilmeModel> ListaAlfabetica = gerarOrdemAlfabetica(ListaFilmes);

            List<FilmeModel> ListaSemifinal = faseEliminatoria(ListaAlfabetica);

            List<FilmeModel> ListaFinal = faseEliminatoria(ListaSemifinal);

            return ListaFinal;

        }






     }
}