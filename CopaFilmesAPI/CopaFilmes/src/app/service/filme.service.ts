import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Filme } from '../model/Filme';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  constructor(public http: HttpClient) { }

  getAllFilmes(){
    return this.http.get("http://localhost:61397/v1/filme")
  }

  // ainda n coloquei
  //getListaFinal(){
  //  return this.http.get("http://localhost:8080/api/resultado")
  //}

  postFilmes(filmes: Filme[]) {
    return this.http.post('http://localhost:61397/v1/filme', filmes)
  }

}