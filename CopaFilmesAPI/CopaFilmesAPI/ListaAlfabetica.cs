using CopaFilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI
{
    public class ListaAlfabetica
    {
        // nao funcionaaaaa
        public List<FilmeModel> GerarOrdemAlfabetica(List<FilmeModel> ListaFilmes)
        {
            ListaFilmes.Sort((x, y) => string.Compare(x.Titulo, y.Titulo));
            //ListaFilmes.OrderBy(x => x.Titulo);

            return ListaFilmes;
        }
    }
}
