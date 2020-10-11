using CopaFilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Service
{
    public interface IFilmeService
    {
        // tirei async daqui
        public Task<List<FilmeModel>> GetAllFilmes();
        List<FilmeModel> GerarOrdemAlfabetica(List<FilmeModel> ListaFilmes);
        List<FilmeModel> FaseEliminatoria(List<FilmeModel> ListaFilmes);
        List<FilmeModel> UltimoCombate(List<FilmeModel> ListaFilmes);
        List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes);
        List<FilmeModel> ExibirCampeoes();
    }
}
