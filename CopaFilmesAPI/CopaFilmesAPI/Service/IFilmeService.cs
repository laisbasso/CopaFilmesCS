using CopaFilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Service
{
    public interface IFilmeService
    {
        Task<List<FilmeModel>> GetAllFilmes(); // tirei async daqui
        List<FilmeModel> GerarOrdemAlfabetica(List<FilmeModel> ListaFilmes);
        List<FilmeModel> FaseEliminatoria(List<FilmeModel> ListaFilmes);
        List<FilmeModel> UltimoCombate(List<FilmeModel> ListaFilmes);
        List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes);
    }
}
