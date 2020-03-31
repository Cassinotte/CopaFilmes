import { Component, OnInit, Input } from "@angular/core";
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-indicacao-subform',
  templateUrl: './indicacao.subform.component.html',
})
export class IndicacaoSubFormComponent implements OnInit {

  constructor() { }

  @Input()
  model: FormGroup

  ngOnInit(): void {

  }

}
