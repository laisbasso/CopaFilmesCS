import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Filme } from '../model/Filme';
import { FilmeService } from '../service/filme.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-campeonato',
  templateUrl: './campeonato.component.html',
  styleUrls: ['./campeonato.component.css'],
})
export class CampeonatoComponent implements OnInit {
  filme: Filme = new Filme();
  listaFilmes: Filme[];
  filmesSelecionados: Filme[];
  toggle: boolean;
  botaoAtivo: string;
  textoBotao: string;

  constructor(private filmeService: FilmeService, public router: Router) {}

  ngOnInit() {
    window.scroll(0, 0);
    this.getAllFilmes();
    this.filmesSelecionados = [];
  }

  getAllFilmes() {
    this.filmeService.getAllFilmes().subscribe((resp: Filme[]) => {
      this.listaFilmes = resp;
    });
    //if (this.listaFilmes == null) {
    //  this.router.navigate(['/error']);
    //}
  }

  postFilmesSelecionados() {
    this.filmeService
      .postFilmesSelecionados(this.filmesSelecionados)
      .subscribe((resp: Filme[]) => {
        this.listaFilmes = resp;
        console.log(this.listaFilmes);
        this.filmeService.filmes = this.listaFilmes;
        this.router.navigate(['/resultado']);
      });
  }

  adicionar(filme) {
    this.toggleBotao(filme.id);
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
        this.postFilmesSelecionados();
      }
    }
  }

  remover(filme) {
    // no splice precisa colocar a posição, seguida da qtde de elementos que quer retirar
    var i = this.filmesSelecionados.indexOf(filme);
    this.filmesSelecionados.splice(i, 1);
    console.log(this.filmesSelecionados);
  }

  toggleBotao(id) {
    this.toggle = !this.toggle;
    this.botaoAtivo = id;
  }

  mudarTextoBotao(id) {
    // problemas:
    // a mensagem de selecionado não fica fixa
    // quando deseleciona aparece a mensagem de selecionado
    // quando tem clique duplo a mensagem não muda
    // dadas as condições, optei por deixar a mensagem de 'SELECIONADO!' em vez de 'REMOVER'
    id === this.botaoAtivo
      ? (this.textoBotao = 'SELECIONADO!')
      : (this.textoBotao = 'SELECIONAR');
    return this.textoBotao;
  }
}
