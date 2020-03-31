import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
import { FilmesResponse } from '../models/filmes.response';

import { map, catchError } from 'rxjs/operators'
import { VencedorViewModel } from '../models/vencedor.viewmodel';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  constructor(private $http: HttpClient,
    @Inject('ApiEndpoint') private apiEndpoint: string) { }

  public getListFilmes = (): Observable<FilmesResponse[]> => {

    return this.$http.get<FilmesResponse[]>(this.apiEndpoint + '/api/filmes', { observe: "response"})
      .pipe(
        map((res: HttpResponse<FilmesResponse[]>) => (<any>res.body).map(item => new FilmesResponse(item))),
        catchError((error: HttpErrorResponse) => throwError(error))
      );

  }

   
  public postInitCopa = (ids: string[]): Observable<VencedorViewModel> => {
    return this.$http.post<VencedorViewModel>(this.apiEndpoint + '/api/filmes/copaInitial', ids, { observe: "response" })
      .pipe(
        map((res: HttpResponse<VencedorViewModel>) => new VencedorViewModel(res.body)),
        catchError((error: HttpErrorResponse) => throwError(error))
      );
  }

}
