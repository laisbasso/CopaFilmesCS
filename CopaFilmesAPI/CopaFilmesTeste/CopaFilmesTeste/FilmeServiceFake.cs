using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmesTeste
{
    class FilmeServiceFake : IFilmeService
    {
        private readonly List<FilmeModel> _filme;
        public FilmeServiceFake()
        {
            _filme = new List<FilmeModel>()
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
        public IEnumerable<FilmeModel> GetAllFilmes()
        {
            return _filme;
        }

        ////// WIP
    }
}
