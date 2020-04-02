import { Injectable, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray, AbstractControl, ValidatorFn } from '@angular/forms';
import { FilmesResponse } from '../models/filmes.response';
import { ToastService } from '../../shared/toast/toast.service';

@Injectable()
export class FilmeValidator {

  constructor(private _formBuilder: FormBuilder, private _toastService: ToastService,
    @Inject('MaxFilmes') public maxFilme: number) {

  }

  canSubmitForm(form: FormGroup) {
    return /*form.valid;  && */ !form.pristine;
  }

  private getFormArray(form: FormGroup, formArray?: FormArray) {
    let formarray = formArray ?? <FormArray>form.get("Filmes");

    return formarray.controls.map(control => control.value).filter(x => x.check);
  }

  countCheck(form: FormGroup) {
    return this.getFormArray(form).length;

  }

  getFormCheck(form: FormGroup) : string[] | null {

    if (form.dirty && form.valid) {

      return this.getFormArray(form).map(x => x.id);

    }
    else {

      let errors = form.get("Filmes").errors;

      for (let key in errors) {
        this._toastService.alert("Validação", errors[key]);
      }

      return null;
    }
  }

  buildForm(filmes: FilmesResponse[]) {
    let fb = this._formBuilder.group({

      "Filmes": this._formBuilder.array(this.buildFormArray(filmes),
        [this.checkEmpty(), this.checkLimit(), this.CheckExact()])

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

  protected checkEmpty(): ValidatorFn {
    return (formArray: FormArray): { [key: string]: any } | null => {

      return this.getFormArray(null, formArray).length ? null : { empty: 'Selecione ao menos um elemento' } ;
    }
  }

  protected checkLimit(): ValidatorFn {

    return (formArray: FormArray): { [key: string]: any } | null => {

      return this.getFormArray(null, formArray).length > this.maxFilme ? { limit: 'Excedeu limite de seleção' } : null;
    }
  }

  protected CheckExact(): ValidatorFn {

    return (formArray: FormArray): { [key: string]: any } | null => {

      return this.getFormArray(null, formArray).length === this.maxFilme ? null : { exact: 'Selecione exatamente 8 filmes' } ;
    }
  }

}
