import { Routes, RouterModule } from "@angular/router";
import { FilmeComponentComponent } from './filme.component.component';
import { ConfirmacaoComponent } from './confirmacao/confirmacao.component';

const routes: Routes = [
  {
    path: '', component: FilmeComponentComponent,
  },
  {
    path: 'confirmacao/:ids', component: ConfirmacaoComponent
  }
];

export const routing = RouterModule.forChild(routes);
