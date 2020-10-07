using CopaFilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI
{
    abstract class Alfabetica
    {
        public List<FilmeModel> OrdenarAlfabetica(List<FilmeModel> ListaFilmes)
        {
            ListaFilmes.OrderBy(x => x.Titulo);

            return ListaFilmes;
        }
    }
}
