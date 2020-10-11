using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmesAPI.Models;
using CopaFilmesAPI.Service;
using System;

namespace CopaFilmesAPI.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        //List<FilmeModel> ListaTeste { get; set; }

        private readonly IFilmeService _service;
        public FilmeController(IFilmeService service)
        {
            _service = service;
        }
                
        [HttpGet("v1")]
        public async Task<List<FilmeModel>> GetAllFilmes()
        {
            return await _service.GetAllFilmes();
        }

        public List<FilmeModel> ListaTeste;

        [HttpPost("v1")]
        public List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes) {

            //this.ListaTeste = _service.PostFilmesSelecionados(ListaFilmes);

            ListaTeste = _service.PostFilmesSelecionados(ListaFilmes);

            return _service.PostFilmesSelecionados(ListaFilmes);
        }

        //será que é uma boa deixar esse v1 aqui mesmo?
        [HttpGet("v1/resultado")]
        public void ExibirCampeoes()
        {

            // aqui era List<FilmeModel>
            //    aqui da null, se deixar com o new list dá array vazio
            //    ListaVencedores = UltimoCombate(ListaFinal);

            //    posso pegar direto no front do post? dai n precisa desse get

            //ListaTeste = _service.PostFilmesSelecionados(ListaFilmes)

            //return _service.ExibirCampeoes();

            try
            {
                Console.WriteLine(ListaTeste);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            //return ListaTeste;
        }
    }
}


