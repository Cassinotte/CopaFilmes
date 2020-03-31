import { FilmesResponse } from './filmes.response';

export class VencedorViewModel {

  public Vencedor1: FilmesResponse;
  public Vencedor2: FilmesResponse;

  constructor(obj?: any) {

    this.Vencedor1 = obj?.Vencedor1 ?? null;
    this.Vencedor2 = obj?.Vencedor2 ?? null;

  }


}
