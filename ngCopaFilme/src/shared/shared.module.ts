import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpSpinnerInterceptor } from './httpinterceptor/http.spinner.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SpinnerComponent, SpinnerService } from './spinner/spinner';
import { HttpErrorInterceptor } from './httpinterceptor/http.error.interceptor';
import { ExceptionService } from './httpinterceptor/exception.service';
import { ToastService, ToastComponent } from './toast/toast';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  imports: [
    NgxSpinnerModule,
    ToastrModule.forRoot()
  ],
  declarations: [
    SpinnerComponent,
    ToastComponent
  ],
  exports: [
    NgxSpinnerModule,
    SpinnerComponent
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        SpinnerService,
        ExceptionService,
        ToastService,
        {
          provide: HTTP_INTERCEPTORS,
          useClass: HttpSpinnerInterceptor,
          multi: true
        },
        {
          provide: HTTP_INTERCEPTORS,
          useClass: HttpErrorInterceptor,
          multi: true
        },
      ]
    }
  }
}
