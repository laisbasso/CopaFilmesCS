using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmesAPI.Models;
using CopaFilmesAPI.Service;

namespace CopaFilmesAPI.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
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

        [HttpPost("v1")]
        public List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes) { 

            return _service.PostFilmesSelecionados(ListaFilmes);
        }

        //será que é uma boa deixar esse v1 aqui mesmo?
        //[HttpGet("v1/resultado")]
        //public List<FilmeModel> ExibirCampeoes()
        //{
        //    aqui da null, se deixar com o new list dá array vazio
        //    ListaVencedores = UltimoCombate(ListaFinal);

        //    posso pegar direto no front do post? dai n precisa desse get

        //    return _service.PostFilmesSelecionados(ListaFilmes);
        //}
    }
}


