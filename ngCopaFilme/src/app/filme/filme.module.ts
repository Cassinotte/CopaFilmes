import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilmeComponentComponent } from './filme.component.component';
import { FilmeValidator } from './filme.validator';
import { FilmeServiceService } from './filme.service.service';
import { routing } from './filme.routing';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    HttpClientModule,
    CommonModule, routing
  ],
  declarations: [FilmeComponentComponent],
  providers: [
    FilmeValidator,
    FilmeServiceService
  ]
})
export class FilmeModule { }
