export class FilmesResponse {

  public id: string;
  public titulo: string;
  public ano: number;
  public nota: number;

  constructor(obj?: any) {
    this.id = obj?.id ?? null
    this.titulo = obj?.titulo ?? null
    this.ano = obj?.ano ?? 0
    this.nota = obj?.Nome ?? 0
  }

}
