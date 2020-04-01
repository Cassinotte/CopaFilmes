import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

export interface ISpinnerState {
  show: boolean
}

@Injectable()
export class SpinnerService {
  private _spinnerSubject = new Subject <ISpinnerState>();
  private count: number = 0;
  spinnerState = <Observable<ISpinnerState>>this._spinnerSubject;

  show() {
      if (this.count < 0) {
          this.count = 0;
      }
      this.count++;
      if (this.count > 0) {
          this._spinnerSubject.next(<ISpinnerState>{ show: true });
    }
  }

  hide() {
      this.count--;
      if (this.count <= 0) {
          this._spinnerSubject.next(<ISpinnerState>{ show: false });
    }
  }
}
