import { Injectable } from '@angular/core';
//import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { finalize, tap } from 'rxjs/operators';
import { SpinnerService } from '../spinner/spinner';

@Injectable()
export class HttpSpinnerInterceptor implements HttpInterceptor {
  constructor(private spinnerService: SpinnerService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
      this.spinnerService.show();
    // extend server response observable with logging
      return next.handle(req)
        .pipe(
          tap(
            // Succeeds when there is a response; ignore other events
            event => { },
            // Operation failed; error is an HttpErrorResponse
          error => { }
        ),
        // Log when response observable either completes or errors
        finalize(() => {
          this.spinnerService.hide();
        })
      );
  }
}
