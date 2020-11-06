import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Programador } from '../models/Programador';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProgramadorService {

  baseURL = `${environment.UrlPrincipal}/Programador`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Programador[]> {
    return this.http.get<Programador[]>(this.baseURL);
  }

  getById(id: number): Observable<Programador> {
    return this.http.get<Programador>(`${this.baseURL}/${id}`);
  }

  getByDisciplinaId(id: number): Observable<Programador[]> {
    return this.http.get<Programador[]>(`${this.baseURL}/ByProjeto/${id}`);
  }

  post(programador: Programador) {
    return this.http.post(this.baseURL, programador);
  }

  put(programador: Programador) {
    return this.http.put(`${this.baseURL}/${programador.id}`, programador);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}