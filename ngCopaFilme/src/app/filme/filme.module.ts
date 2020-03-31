import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilmeComponentComponent } from './filme.component.component';
import { FilmeValidator } from './filme.validator';
import { FilmeService } from './filme.service';
import { routing } from './filme.routing';
import { HttpClientModule } from '@angular/common/http';
import { IndicacaoFormArrayComponent } from './indicacao/indicacao.formarray.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IndicacaoSubFormComponent } from './indicacao/indicacao.subForm.component';
import { ConfirmacaoComponent } from './confirmacao/confirmacao.component';


@NgModule({
  imports: [routing, CommonModule,
    FormsModule,
    ReactiveFormsModule ],
  declarations: [FilmeComponentComponent, IndicacaoFormArrayComponent, IndicacaoSubFormComponent, ConfirmacaoComponent],
  providers: [
    FilmeValidator,
    FilmeService
  ]
})
export class FilmeModule { }
