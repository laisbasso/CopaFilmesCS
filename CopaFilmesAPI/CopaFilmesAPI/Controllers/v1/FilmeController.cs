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

            return _service.PostFilmesSelecionados(ListaFilmes);
        }
    }
}


