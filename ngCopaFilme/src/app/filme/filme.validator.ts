import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FilmesResponse } from '../models/filmes.response';

@Injectable()
export class FilmeValidator {

  constructor(private _formBuilder: FormBuilder) {

  }


  buildForm(filmes: FilmesResponse[]) {
    let fb = this._formBuilder.group({

      "Filmes": this._formBuilder.array(this.buildFormArray(filmes))

    });

    return fb;
  }

  buildFormArray(filmes: FilmesResponse[]): any[] {

    let retorno: FormGroup[];

    retorno = filmes.map(x => this._formBuilder.group({
      "id": [x.id, []],
      "titulo": [x.titulo, []],
      "ano": [x.ano, []],
      "nota": [x.nota, []],
    }));

    return retorno;

  }

}
