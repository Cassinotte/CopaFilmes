import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';

import { ISpinnerState, SpinnerService } from './spinner.service';
// https://github.com/Napster2210/ngx-spinner
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
    selector: 'cassinotte-spinner',
    template: `
            <ngx-spinner
              bdColor="rgba(51,51,51,0.8)"
              size="medium"
              color="#fff"
              loadingText="Carregando..."
              type="ball-clip-rotate-multiple">
            </ngx-spinner>
    `
})

export class SpinnerComponent implements OnDestroy, OnInit {

    private _spinnerStateChanged: Subscription;

    constructor(private _spinnerService: SpinnerService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    // inicial para que ele comece com o spinner até que tenha os requests iniciais
    this.spinner.show();
    this._spinnerStateChanged = this._spinnerService.spinnerState.subscribe((state: ISpinnerState) => {
        if (state.show) {
          this.spinner.show();
        } else {
          this.spinner.hide();
        }
      });
    }

    ngOnDestroy() {
        this._spinnerStateChanged.unsubscribe();
    }
}
