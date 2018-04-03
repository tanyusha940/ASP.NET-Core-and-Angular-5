import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { NewConspectComponent } from "./new-conspect.component";

const routes: Routes = [
    Route.withShell([
      { path: 'new', component: NewConspectComponent, data: { title: extract('New') } }
    ])
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    providers: []
  })
  export class NewConspectRoutingModule { }