import { Component, OnInit } from '@angular/core';
import { FilmeServiceService } from './filme.service.service';
import { FormGroup } from '@angular/forms';
import { FilmeValidator } from './filme.validator';

@Component({
  selector: 'app-filme-component',
  templateUrl: './filme.component.component.html',
  styleUrls: ['./filme.component.component.css']
})
export class FilmeComponentComponent implements OnInit {

  maxFilme: number = 8;

  formFilme: FormGroup;

  constructor(private _service: FilmeServiceService, private _validator: FilmeValidator) { }

  ngOnInit(): void {

    this._service.getListFilmes().subscribe(x => {

      this.formFilme = this._validator.buildForm(x);

    })

  }

  countCheck() {
    return this._validator.countCheck(this.formFilme);
  }

  enableSubmit() {
    return this._validator.canSubmitForm(this.formFilme);
  }

  onSubmit() {

  }

}
