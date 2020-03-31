import { Component, OnInit } from '@angular/core';
import { FilmeService} from './filme.service';
import { FormGroup } from '@angular/forms';
import { FilmeValidator } from './filme.validator';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-filme-component',
  templateUrl: './filme.component.component.html',
  styleUrls: ['./filme.component.component.css']
})
export class FilmeComponentComponent implements OnInit {

  maxFilme: number = 8;

  formFilme: FormGroup;

  constructor(private _service: FilmeService, private _validator: FilmeValidator,
    private _router: Router, private _route: ActivatedRoute) { }

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

    let dados = this._validator.getFormCheck(this.formFilme);

    this._router.navigate(['confirmacao', dados.join(";")], { relativeTo: this._route });

  }

}
