import { Routes, RouterModule } from "@angular/router";
import { FilmeComponentComponent } from './filme.component.component';

const routes: Routes = [
  {
    path: '', component: FilmeComponentComponent
  }
];

export const routing = RouterModule.forChild(routes);
