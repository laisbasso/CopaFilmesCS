import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Filme } from '../model/Filme';
import { FilmeService } from '../service/filme.service';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css'],
})
export class ResultadoComponent implements OnInit {
  listaFilmes: Filme[];

  constructor(
    private filmeService: FilmeService,
    private router: Router
  ) {}

  ngOnInit() {
    window.scroll(0, 0)
    this.getCampeoes()
    this.listaFilmes
  }

  getCampeoes() {
    this.listaFilmes
    this.filmeService.getCampeoes().subscribe((resp: Filme[]) => {
      this.listaFilmes = resp;
      console.log(this.listaFilmes)
    });
  }

  voltar() {
    this.router.navigate(['/campeonato']);
  }
}