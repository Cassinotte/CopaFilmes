import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { FilmesResponse } from '../models/filmes.response';

@Injectable()
export class FilmeValidator {

  constructor(private _formBuilder: FormBuilder) {

  }

  canSubmitForm(form: FormGroup) {
    return form.valid && !form.pristine;
  }

  private getFormArray(form: FormGroup) {
    let formarray = <FormArray>form.get("Filmes");

    return formarray.controls.map(control => control.value).filter(x => x.check);
  }

  countCheck(form: FormGroup) {
    return this.getFormArray(form).length;

  }

  getFormCheck(form: FormGroup) : string[] {

    if (form.dirty && form.valid) {

      return this.getFormArray(form).map(x => x.id);

    }
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
      "check": [false, []],
      "id": [x.id, []],
      "titulo": [x.titulo, []],
      "ano": [x.ano, []],
      "nota": [x.nota, []],
    }));

    return retorno;

  }

}
