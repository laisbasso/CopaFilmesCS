using CopaFilmesAPI.Models;
using CopaFilmesAPI.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmesTeste
{
    class FilmeServiceFake : IFilmeService
    {
        private readonly List<FilmeModel> _filme;
        public FilmeServiceFake()
        {

            ////// WIP


            _filme = new IEnumerable<FilmeModel>()
            {
                new FilmeModel() {"id"="tt2854926","titulo"="Te Peguei!","ano"=2018,"nota"=7.1},

                new FilmeModel() {"id"="tt0317705","titulo"="Os Incríveis","ano"=2004,"nota"=8.0},

                new FilmeModel() {"id"="tt3799232","titulo"="A Barraca do Beijo","ano"=2018,"nota"=6.4},

                new FilmeModel() {"id"="tt1365519","titulo"="Tomb Raider: A Origem","ano"=2018,"nota"=6.5},

                new FilmeModel() {"id"="tt1825683","titulo"="Pantera Negra","ano"=2018,"nota"=7.5},

                new FilmeModel() {"id"="tt7690670","titulo"="Superfly","ano"=2018,"nota"=5.1},

                new FilmeModel() {"id"="tt6499752","titulo"="Upgrade","ano"=2018,"nota"=7.8}
            };
        }

        Task<List<FilmeModel>> IFilmeService.GetAllFilmes()
        {
            throw new NotImplementedException();
        }

        public List<FilmeModel> GerarOrdemAlfabetica(List<FilmeModel> ListaFilmes)
        {
            throw new NotImplementedException();
        }

        public List<FilmeModel> FaseEliminatoria(List<FilmeModel> ListaFilmes)
        {
            throw new NotImplementedException();
        }

        public List<FilmeModel> UltimoCombate(List<FilmeModel> ListaFilmes)
        {
            throw new NotImplementedException();
        }
        public List<FilmeModel> PostFilmesSelecionados(List<FilmeModel> ListaFilmes)
        {
            throw new NotImplementedException();
        }

        public List<FilmeModel> ExibirCampeoes()
        {
            throw new NotImplementedException();
        }
    }
}
