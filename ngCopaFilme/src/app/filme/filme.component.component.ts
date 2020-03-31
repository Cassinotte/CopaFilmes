import { Component, OnInit } from '@angular/core';
import { FilmeServiceService } from './filme.service.service';

@Component({
  selector: 'app-filme-component',
  templateUrl: './filme.component.component.html',
  styleUrls: ['./filme.component.component.css']
})
export class FilmeComponentComponent implements OnInit {

  constructor(private _service: FilmeServiceService) { }

  ngOnInit(): void {

  }

}
