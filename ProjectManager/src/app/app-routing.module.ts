import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProgramadoresComponent } from './programadores/programadores.component';
import { ProjetosComponent } from './projetos/projetos.component';

const routes: Routes = [
    {path: '' , redirectTo:'dashboard', pathMatch: 'full'},
    {path: 'programadores', component: ProgramadoresComponent},
    {path: 'projetos', component: ProjetosComponent},
    {path: 'dashboard', component: DashboardComponent}
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
