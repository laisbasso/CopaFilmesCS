import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Filme } from '../model/Filme';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  constructor(public http: HttpClient) { }

  getAllFilmes(){
    return this.http.get("http://localhost:61397/filme/v1")
  }

  getCampeoes(){
    return this.http.get("http://localhost:61397/filme/v1/resultado")

  }

  postFilmesSelecionados(filmes: Filme[]) {
    return this.http.post('http://localhost:61397/filme/v1', filmes)
  }

}