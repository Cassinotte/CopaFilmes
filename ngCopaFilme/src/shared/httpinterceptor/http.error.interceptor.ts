import { Injectable } from '@angular/core';
//import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { finalize, tap } from 'rxjs/operators';
import { ExceptionService } from './exception.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private exceptionService: ExceptionService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const started = Date.now();
    let ok: string;

    // extend server response observable with logging
    return next.handle(req)
      .pipe(
        tap(
          // Succeeds when there is a response; ignore other events
          event => { },
          // Operation failed; error is an HttpErrorResponse
          error => this.exceptionService.catchBadResponse(error)
        ),
        // Log when response observable either completes or errors
        finalize(() => {
          //const elapsed = Date.now() - started;
          //const msg = `${req.method} "${req.urlWithParams}"
          //   ${ok} in ${elapsed} ms.`;
          //this.exceptionService.add(msg);
        })
      );
  }
}
