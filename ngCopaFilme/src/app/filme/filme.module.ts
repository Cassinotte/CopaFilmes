import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilmeComponentComponent } from './filme.component.component';
import { FilmeValidator } from './filme.validator';
import { FilmeServiceService } from './filme.service.service';
import { routing } from './filme.routing';
import { HttpClientModule } from '@angular/common/http';
import { IndicacaoFormArrayComponent } from './indicacao/indicacao.formarray.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { IndicacaoSubFormComponent } from './indicacao/indicacao.subForm.component';


@NgModule({
  imports: [ routing ],
  declarations: [FilmeComponentComponent, IndicacaoFormArrayComponent, IndicacaoSubFormComponent],
  providers: [
    FilmeValidator,
    FilmeServiceService
  ]
})
export class FilmeModule { }
