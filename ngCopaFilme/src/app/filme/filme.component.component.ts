import { Component, OnInit } from '@angular/core';
import { FilmeServiceService } from './filme.service.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-filme-component',
  templateUrl: './filme.component.component.html',
  styleUrls: ['./filme.component.component.css']
})
export class FilmeComponentComponent implements OnInit {

  maxFilme: number = 8;

  formFilme: FormGroup;

  constructor(private _service: FilmeServiceService) { }

  ngOnInit(): void {

  }

  onSubmit() {

  }

}
