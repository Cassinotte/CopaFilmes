import { Component, OnInit, Input } from '@angular/core';
import { FormArray } from '@angular/forms';

@Component({
  selector: 'app-indicacao-formarray',
  templateUrl: './indicacao.formarray.component.html',
})
export class IndicacaoFormArrayComponent implements OnInit {

  constructor() { }

  @Input()
  formArray: FormArray

  ngOnInit(): void {

  }

}
