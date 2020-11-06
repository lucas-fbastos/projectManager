import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Projeto } from '../models/Projeto';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProjetoService {

  baseURL = `${environment.UrlPrincipal}/Projeto`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Projeto[]> {
    return this.http.get<Projeto[]>(this.baseURL);
  }

  getById(id: number): Observable<Projeto> {
    return this.http.get<Projeto>(`${this.baseURL}/${id}`);
  }

  getByDisciplinaId(id: number): Observable<Projeto[]> {
    return this.http.get<Projeto[]>(`${this.baseURL}/ByProgramador/${id}`);
  }

  post(projeto: Projeto) {
    return this.http.post(this.baseURL, projeto);
  }

  put(projeto: Projeto) {
    return this.http.put(`${this.baseURL}/${projeto.id}`, projeto);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}