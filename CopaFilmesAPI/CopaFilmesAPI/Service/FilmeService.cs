using CopaFilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IHttpClientFactory _clientFactory;

        //construtor
        public FilmeService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IEnumerable<FilmeModel> ListaIEnumerable { get; set; }
        public List<FilmeModel> ListaFilmes;



        public List<FilmeModel> ListaTestezinho { get; set; }

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

        public List<FilmeModel> GerarOrdemAlfabetica(List<FilmeModel> ListaFilmes)
        {
            ListaFilmes.Sort((x, y) => string.Compare(x.Titulo, y.Titulo));

            return ListaFilmes;
        }

        public List<FilmeModel> FaseEliminatoria(List<FilmeModel> ListaFilmes)
        {
            List<FilmeModel> FilmesVencedores = new List<FilmeModel>();

            int posicaoB = ListaFilmes.Count() - 1;

            for (int posicaoA = 0; posicaoA < posicaoB; posicaoA++)
            {
                int posicaoVencedora = ListaFilmes[posicaoA].Nota >= ListaFilmes[posicaoB].Nota ?
                     posicaoA : posicaoB;

                FilmesVencedores.Add(ListaFilmes[posicaoVencedora]);
                posicaoB--;
            }

            return FilmesVencedores;
        }

        public List<FilmeModel> UltimoCombate(List<FilmeModel> ListaFilmes)
        {
            FilmeModel trocarElemento;

            if (ListaFilmes[0].Nota < ListaFilmes[1].Nota)
            {
                trocarElemento = ListaFilmes[0];
                ListaFilmes[0] = ListaFilmes[1];
                ListaFilmes[1] = trocarElemento;
            }

            return ListaFilmes;
        }

        List<FilmeModel> ListaAlfabetica;
        List<FilmeModel> ListaSemifinal;
        List<FilmeModel> ListaFinal;
        List<FilmeModel> ListaVencedores;

        public List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes)
        {
            ListaAlfabetica = GerarOrdemAlfabetica(ListaFilmes);
            ListaSemifinal = FaseEliminatoria(ListaAlfabetica);
            ListaFinal = FaseEliminatoria(ListaSemifinal);
            ListaVencedores = UltimoCombate(ListaFinal);

            ListaTestezinho = ListaVencedores;

            return ListaVencedores;
        }

        public List<FilmeModel> ExibirCampeoes()
        {
            return ListaTestezinho;
        }
    }
}
