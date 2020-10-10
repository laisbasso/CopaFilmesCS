import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultadoComponent } from './resultado/resultado.component';
import { CampeonatoComponent } from './campeonato/campeonato.component';

const routes: Routes = [
  { path: '', redirectTo: 'campeonato', pathMatch: 'full' },
  { path: 'campeonato', component: CampeonatoComponent },
  { path: 'resultado', component: ResultadoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }