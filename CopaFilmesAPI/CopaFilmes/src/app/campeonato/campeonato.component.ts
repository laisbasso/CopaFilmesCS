import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Filme } from '../model/Filme';
import { FilmeService } from '../service/filme.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-campeonato',
  templateUrl: './campeonato.component.html',
  styleUrls: ['./campeonato.component.css']
})
export class CampeonatoComponent implements OnInit {
  filme: Filme = new Filme();
  listaFilmes: Filme[];
  filmesSelecionados: Filme[];

  constructor(private filmeService: FilmeService, public router: Router) {}

  ngOnInit() {
    window.scroll(0, 0);
    this.findAllFilmes();
    this.filmesSelecionados = [];
  }

  findAllFilmes() {
    this.filmeService.getAllFilmes().subscribe((resp: Filme[]) => {
      this.listaFilmes = resp;
    });
  }

  postFilmes() {
    this.filmeService
      .postFilmes(this.filmesSelecionados)
      .subscribe((resp: Filme[]) => {
        this.listaFilmes = resp;
        console.log(this.listaFilmes);
        this.router.navigate(['/resultado']);
      });
  }

  adicionar(filme) {
    document.getElementById("filme.id").classList.toggle("toggle-borda-card");
    if (this.filmesSelecionados.includes(filme)) {
      this.remover(filme);
    } else {
      if (this.filmesSelecionados.length < 8) {
        this.filmesSelecionados.push(filme);
        console.log(this.filmesSelecionados);
      } else {
        Swal.fire({
          icon: 'warning',
          title:
            'Você já selecionou filmes suficientes, agora vamos conhecer o campeão?',
          showConfirmButton: false,
          timer: 4000,
        });
        this.postFilmes();
      }
    }
  }

  remover(filme) {
    // no splice precisa colocar a posição, seguida da qtde de elementos que quer retirar
    var i = this.filmesSelecionados.indexOf(filme);
    this.filmesSelecionados.splice(i, 1);
    console.log(this.filmesSelecionados);
  }
}
