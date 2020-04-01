import { Injectable } from '@angular/core';
//import { NotificationsService } from "angular2-notifications/components";
import { Router, NavigationEnd } from '@angular/router';


// https://github.com/scttcper/ngx-toastr
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ToastService {
  private errors: string[] = [];

  constructor(private toastr: ToastrService, private _router: Router) {
        _router.events.subscribe((event) => {
            if (event instanceof NavigationEnd) {
              this.toastr.clear();
            }
            // NavigationEnd
            // NavigationCancel
            // NavigationError
            // RoutesRecognized
        });
    }
    success(title: string, content: string): void {
        this.toastr.success(content, title);
        //this._service.success(title, content);
    };

    error(title: string | string[], content: string): void {
        if (Array.isArray(title)) {
            for (let msg of title) {
                var error = this.toastr.error(content, msg);
              //this.errors.push(error.id);
            }
        }
        else {
            var error = this.toastr.error(content, title);
            //this.errors.push(error.id);
        }
    };

    alert(title: string, content: string): void {
        this.toastr.warning(content, title);
    };

    info(title: string, content: string): void {
        this.toastr.info(content, title);
    };

    infoNotClose(title: string, content: string): void {
        this.toastr.info(content, title, {
            timeOut: 0, closeButton: true, disableTimeOut: false, extendedTimeOut: 0
        });
    }

}
