import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Projeto } from '../models/Projeto';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DashBoardService {

  baseURL = `${environment.UrlPrincipal}/DadosEstatisticos`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Projeto[]> {
    return this.http.get<any[]>(this.baseURL+'/projetos');
  }

  

}