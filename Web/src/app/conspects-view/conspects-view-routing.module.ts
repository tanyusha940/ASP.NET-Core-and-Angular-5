import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Route, extract } from '@app/core';
import { ConspectListComponent } from './conspect-list/conspect-list.component';

const routes: Routes = [
      Route.withShell([
          { path: 'list', component: ConspectListComponent, data: { title: extract('Personal Page') } }
      ])
  ];

@NgModule({
imports: [RouterModule.forChild(routes)],
exports: [RouterModule],
providers: []
})
export class ConspectsViewRoutingModule { }
