import { FilmesResponse } from './filmes.response';

export class VencedorViewModel {

  public vencedor1: FilmesResponse;
  public vencedor2: FilmesResponse;

  constructor(obj?: any) {

    this.vencedor1 = obj?.vencedor1 ?? null;
    this.vencedor2 = obj?.vencedor2 ?? null;

  }


}
