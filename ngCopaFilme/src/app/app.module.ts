import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [
    {
      provide: 'ApiEndpoint',
      useFactory: (endpoint: string) => "http://localhost/CopaFilmeWeb",
      deps: []
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
