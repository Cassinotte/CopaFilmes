import { Component, OnInit, OnDestroy } from '@angular/core';
import { FilmeService } from '../filme.service';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { VencedorViewModel } from '../../models/vencedor.viewmodel';

@Component({
  templateUrl: './confirmacao.component.html',
  styleUrls: ['./confirmacao.component.css']
})
export class ConfirmacaoComponent implements OnInit, OnDestroy {

  private _routerSubscr: Subscription;
  vencedores: VencedorViewModel;

  constructor(private _service: FilmeService, private _router: Router, private _route: ActivatedRoute) { }

  ngOnInit(): void {

    this._routerSubscr = this._route.params
      .pipe(
        switchMap(params => this._service.postInitCopa(params["ids"].split(";")))
      )
     .subscribe(x => this.vencedores = x);

  }

  ngOnDestroy(): void {
    this._routerSubscr.unsubscribe();
  }

}
